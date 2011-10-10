using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FluentNHibernate;
using SiqualRunner.Core.Entities;
using SiqualRunner.Core.Entities.mappings;
using SiqualRunner.Core.Mappers;
using SiqualRunner.Core.Repositories;
using SiqualRunner.Core.Services;
using SiqualRunner.Infrastructure;
using StructureMap;
using Timer = System.Windows.Forms.Timer;

namespace SiqualRunner
{
  public enum EnumFilesSelectedInGrid
  {
    NoFiles,
    OneFile,
    MultipleFiles
  }

  public partial class Form1 : BaseForm
  {
    private readonly IProjectRepository _projectRepository = ObjectFactory.GetInstance<IProjectRepository>();
    private readonly IFileSynchronizer _fileSynchronizer = ObjectFactory.GetInstance<IFileSynchronizer>();

    private int _rowIndexLastClicked = -1;
    private EnumFilesSelectedInGrid _filesSelectedInGridStatus;
    private readonly Timer _timer = new Timer();
    private int _lastNotification;
    private bool _mouseButtonIsPressed;
    private bool _controlIsPressed;

    public Form1 ( )
    {
      InitializeComponent();

      if (!File.Exists("SiqualRunner.db"))
      {
        ISessionSource s = new SessionSource(new SQLRPersistenceModel());
        s.BuildSchema();
      }

      toolTip1.SetToolTip(chkRunAtomic, "All files are ran in one transaction.");


      PrepareGridView();
      InitPanels();

      Closing += Form1Closing;
      gvFileList.MouseUp += GvFileListMouseUp;
      notifyIcon.Click += NotifyIconClick;
      Resize += Form1Resize;

      lstProjects.DrawMode = DrawMode.OwnerDrawVariable;
      lstProjects.DrawItem += ListBox1DrawItem;
      lstProjects.MeasureItem += ListBox1MeasureItem;

      _timer.Interval = 1000 * 60 * 3; // 3 minutes
      _timer.Enabled = true;
      _timer.Tick += TimerTick;
      _timer.Start();
    }

    private void ListBox1DrawItem ( object sender, DrawItemEventArgs e )
    {
      if (e.Index >= 0 && e.Index < lstProjects.Items.Count)
      {
        var proj = (Project)lstProjects.Items[e.Index];

        e.DrawBackground();
        e.DrawFocusRectangle();
        e.Graphics.DrawString(
          "> " + proj.ProjectName,
          new Font("Verdana", 14.0f, FontStyle.Regular, GraphicsUnit.Pixel),
          new SolidBrush(e.ForeColor),
          0, 3 + e.Index * 26);
      }
    }

    private void ListBox1MeasureItem ( object sender, MeasureItemEventArgs e )
    {
      e.ItemHeight = 13 * 2;
    }

    void NotifyIconClick ( object sender, EventArgs e )
    {
      if (WindowState != FormWindowState.Minimized) return;

      Show();
      WindowState = FormWindowState.Normal;
      ShowInTaskbar = true;
    }

    void GvFileListMouseUp ( object sender, MouseEventArgs e )
    {
      _mouseButtonIsPressed = false;
    }

    void Form1Resize ( object sender, EventArgs e )
    {
      gvFileList.Columns[0].Width = gvFileList.Width - 10 - 50;
      gvFileList.Columns[1].Width = 50;

      if (WindowState == FormWindowState.Minimized)
      {
        Hide();
        return;
      }
      Show();
    }


    private void InitPanels ( )
    {
      pnlProjectList.Visible = true;
      btnLoadProject.Visible = false;
      pnlFileList.Visible = false;

      using (NHTransaction)
      {
        IList<Project> projects = _projectRepository.LoadAll();
        lstProjects.DataSource = null;
        lstProjects.DataSource = projects;
      }
    }

    private void PrepareGridView ( )
    {
      gvFileList.CellFormatting += GvFilesCellFormatting;
      gvFileList.AutoGenerateColumns = false;
      gvFileList.ShowCellToolTips = true;
      gvFileList.CellToolTipTextNeeded += GvFilesCellToolTipTextNeeded;
      gvFileList.CellContextMenuStripNeeded += GvFilesCellContextMenuStripNeeded;
      gvFileList.CellMouseDown += GvFileListCellMouseDown;
      gvFileList.SelectionChanged += GvFileListSelectionChanged;
      gvFileList.MouseDown += GvFileListMouseDown;
      gvFileList.CellMouseEnter += GvFileListCellMouseEnter;


      DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
      col.DataPropertyName = "FileName";
      col.HeaderText = "File Name";
      col.Width = gvFileList.Width - 10 - 50;
      col.DefaultCellStyle.BackColor = Color.LemonChiffon;
      gvFileList.Columns.Add(col);

      DataGridViewImageColumn col1 = new DataGridViewImageColumn();
      col1.DataPropertyName = "RunStatus";
      col1.HeaderText = "Status";
      col1.Width = 50;
      col1.DefaultCellStyle.BackColor = Color.LemonChiffon;
      gvFileList.Columns.Add(col1);
    }

    void GvFileListCellMouseDown ( object sender, DataGridViewCellMouseEventArgs e )
    {
      if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
      {
        if (_controlIsPressed)
        {
          gvFileList.Rows[e.RowIndex].Selected = true;
        }
        else
        {
          gvFileList.CurrentCell = gvFileList.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
      }
    }


    void GvFileListMouseDown ( object sender, MouseEventArgs e )
    {
      DataGridView.HitTestInfo hitTest = gvFileList.HitTest(e.X, e.Y);
      if (hitTest.Type == DataGridViewHitTestType.Cell) return;

      _mouseButtonIsPressed = true;
      gvFileList.ClearSelection();
    }

    void GvFileListSelectionChanged ( object sender, EventArgs e )
    {
      if (gvFileList.SelectedRows.Count == 0)
      {
        _filesSelectedInGridStatus = EnumFilesSelectedInGrid.NoFiles;
        btnRunScripts.Text = "Run new files";
        return;
      }
      if (gvFileList.SelectedRows.Count == 1)
      {
        _filesSelectedInGridStatus = EnumFilesSelectedInGrid.OneFile;
        btnRunScripts.Text = "Run selected file";
        return;
      }

      _filesSelectedInGridStatus = EnumFilesSelectedInGrid.MultipleFiles;
      btnRunScripts.Text = "Run selected files";
    }


    private void GvFilesCellFormatting ( object sender, DataGridViewCellFormattingEventArgs e )
    {
      if (e.ColumnIndex != 1) return;

      e.Value = ImageFactory.GetStatusImg((EnumRunStatus)e.Value);
    }

    private void GvFilesCellContextMenuStripNeeded ( object sender, DataGridViewCellContextMenuStripNeededEventArgs e )
    {
      _rowIndexLastClicked = e.RowIndex;
    }

    private void GvFilesCellToolTipTextNeeded ( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
    {
      if (e.ColumnIndex != 1 || e.RowIndex < 0) return;

      SiqualFileDisplay file = (SiqualFileDisplay)gvFileList.Rows[e.RowIndex].DataBoundItem;

      e.ToolTipText = file.ErrorMessage;
    }

    void Form1Closing ( object sender, CancelEventArgs e )
    {

    }

    private void StripOpenFileClick ( object sender, EventArgs e )
    {
      if (_rowIndexLastClicked == -1) return;
      SiqualFileDisplay file = gvFileList.Rows[_rowIndexLastClicked].DataBoundItem as SiqualFileDisplay;

      if (file == null) return;

      System.Diagnostics.Process.Start(file.FilePath);
    }

    private void lstProjects_DoubleClick ( object sender, EventArgs e )
    {
      if (lstProjects.SelectedItem == null) return;

      Project project = lstProjects.SelectedItem as Project;
      if (project == null) return;

      SiqualRunnerContext.CurrentProject = project;
      if (!SiqualRunnerContext.CurrentProject.HasAtLeasOnDBConfigured)
      {
        MessageBox.Show("No Database Server is configured for this project. Please complete the configuration.");
        return;
      }

      if (SiqualRunnerContext.SelectedServer.Files.Count == 0)
        SyncWithFolder();

      DatabindFileGrid(project);

      pnlProjectList.Visible = false;
      pnlFileList.Visible = true;
      btnLoadProject.Visible = true;
    }

    private void DatabindFileGrid ( Project project )
    {
      DatabaseServer databaseServer = project.GetDefaultDatabaseServer();
      if (databaseServer == null) return;
      int index = gvFileList.FirstDisplayedScrollingRowIndex;

      gvFileList.DataSource = null;
      gvFileList.DataSource = databaseServer.Files.MapAllUsing(new SiqualFileMapper(databaseServer))
                                            .OrderBy(x => x.FileName, new NumericThenAlphabeticComparer())
                                            .ToList();
      gvFileList.ClearSelection();
      if (index > -1 && gvFileList.Rows.Count >= index)
      {
        gvFileList.FirstDisplayedScrollingRowIndex = index;
      }
    }

    private void StripSyncFilesFromFolderClick ( object sender, EventArgs e )
    {
      SyncWithFolder();
    }

    private void SyncWithFolder ( )
    {
      Project project = SiqualRunnerContext.CurrentProject;
      DatabaseServer server = SiqualRunnerContext.SelectedServer;

      if (project == null)
        return;
      if (server == null)
        return;

      bool syncedSomeFiles = _fileSynchronizer.SyncFileCollectionFromPath(server.Files, server, project);
      if (!syncedSomeFiles) return;

      using (NHTransaction)
      {
        _projectRepository.SaveOrUpdate(project);
      }
      DatabindFileGrid(project);
    }

    void TimerTick ( object sender, EventArgs e )
    {
      SyncWithFolder();
      SetNotifyIcon();
    }

    private void StripEditProjectClick ( object sender, EventArgs e )
    {
      Project project = lstProjects.SelectedItem as Project;
      if (project == null) return;

      FrmProjectSettings s = new FrmProjectSettings(project);
      s.ShowDialog();
      InitPanels();
      SiqualRunnerContext.CurrentProject = project;
    }

    private void BtnRunScriptsClick ( object sender, EventArgs e )
    {
      BackgroundScriptRunner backgroundScriptRunner = new BackgroundScriptRunner();
      backgroundScriptRunner.ProgressChanged += BackgroundScriptRunnerProgressChanged;
      switch (_filesSelectedInGridStatus)
      {
        case EnumFilesSelectedInGrid.NoFiles:
          statusLabel.SetInWork();
          backgroundScriptRunner.RunNewScripts(SiqualRunnerContext.SelectedServer, chkRunAtomic.Checked);
          break;
        case EnumFilesSelectedInGrid.OneFile:
          RunSelectedFile(backgroundScriptRunner);
          return;
        case EnumFilesSelectedInGrid.MultipleFiles:
          {
            IList<int> ids = GetFileIdsFromSelectedRows();
            statusLabel.SetInWork();
            backgroundScriptRunner.RunScripts(SiqualRunnerContext.SelectedServer, ids, chkRunAtomic.Checked);
          }
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void RunSelectedFile ( BackgroundScriptRunner backgroundScriptRunner )
    {
      if (gvFileList.SelectedRows.Count != 1) return;
      SiqualFileDisplay fileDisplay = gvFileList.SelectedRows[0].DataBoundItem as SiqualFileDisplay;
      if (fileDisplay == null) return;
      statusLabel.SetInWork();
      backgroundScriptRunner.RunScript(SiqualRunnerContext.SelectedServer, fileDisplay.Id, chkRunAtomic.Checked);
    }


    private void ShowNotificationIcon ( string message )
    {
      notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
      notifyIcon.BalloonTipTitle = "Info";
      notifyIcon.BalloonTipText = message;
      notifyIcon.ShowBalloonTip(2000);
    }

    private void GvFileListCellMouseEnter ( object sender, DataGridViewCellEventArgs e )
    {
      if (!_mouseButtonIsPressed) return;

      gvFileList.Rows[e.RowIndex].Selected = true;

    }

    private IList<int> GetFileIdsFromSelectedRows ( )
    {
      if (gvFileList.SelectedRows.Count == 0) return new List<int>();

      IList<int> ids = new List<int>();
      foreach (DataGridViewRow row in gvFileList.SelectedRows)
      {
        SiqualFileDisplay fileDisplay = (SiqualFileDisplay)row.DataBoundItem;
        ids.Add(fileDisplay.Id);
      }

      return ids;
    }

    private void BackgroundScriptRunnerProgressChanged ( object sender, ProgressChangedEventArgs e )
    {
      if (e.ProgressPercentage != 100) return;

      DatabindFileGrid(SiqualRunnerContext.CurrentProject);
      statusLabel.SetIdle();

      using (NHTransaction)
      {
        _projectRepository.SaveOrUpdate(SiqualRunnerContext.CurrentProject);
      }
    }

    private void MToolStripMenuItemClick ( object sender, EventArgs e )
    {
      IList<int> ids = GetFileIdsFromSelectedRows();
      SiqualRunnerContext.SelectedServer.MarkFilesAsRan(ids);

      using (NHTransaction)
      {
        _projectRepository.SaveOrUpdate(SiqualRunnerContext.CurrentProject);
      }

      DatabindFileGrid(SiqualRunnerContext.CurrentProject);
    }

    private void SetNotifyIcon ( )
    {
      if (SiqualRunnerContext.SelectedServer == null) return;
      int count = SiqualRunnerContext.SelectedServer.GetNotRanScripts().Count;

      if (_lastNotification == count) return;

      _lastNotification = count;
      if (count != 0)
      {
        notifyIcon.Icon = Properties.Resources.needToRun;
        ShowNotificationIcon("You have " + count + " scripts not executed.");
      }
      else
        notifyIcon.Icon = Properties.Resources.scriptsOK;
    }

    private void OpenDirectoryToolStripMenuItemClick ( object sender, EventArgs e )
    {
      if (_rowIndexLastClicked == -1) return;
      SiqualFileDisplay file = gvFileList.Rows[_rowIndexLastClicked].DataBoundItem as SiqualFileDisplay;

      if (file != null) System.Diagnostics.Process.Start(Path.GetDirectoryName(file.FilePath));
    }

    private void MRunSelectedClick ( object sender, EventArgs e )
    {
      BackgroundScriptRunner backgroundScriptRunner = new BackgroundScriptRunner();
      backgroundScriptRunner.ProgressChanged += BackgroundScriptRunnerProgressChanged;

      RunSelectedFile(backgroundScriptRunner);

    }

    private void Form1KeyDown ( object sender, KeyEventArgs e )
    {
      _controlIsPressed = e.Control;
    }

    private void Form1KeyUp ( object sender, KeyEventArgs e )
    {
      _controlIsPressed = false;
    }

    private void BtnNewProjectClick ( object sender, EventArgs e )
    {
      FrmProjectSettings s = new FrmProjectSettings(null);
      s.ShowDialog();
      InitPanels();
    }

    private void BtnLoadProjectClick ( object sender, EventArgs e )
    {
      InitPanels();
    }

    private void ExitToolStripMenuItemClick ( object sender, EventArgs e )
    {
      Close();
    }

    private void BtnMergeAllClick ( object sender, EventArgs e )
    {
      var currentProject = SiqualRunnerContext.CurrentProject;
      if (currentProject == null)
        return;

      var defaultDatabaseServer = currentProject.GetDefaultDatabaseServer();

      StringBuilder mergedScript = new StringBuilder();

      foreach (var siqualFile in defaultDatabaseServer.Files.OrderBy(x => x.FileName, new NumericThenAlphabeticComparer()))
      {
        mergedScript.Append(File.ReadAllText(siqualFile.FullFilePath));
        mergedScript.AppendLine();
        mergedScript.AppendLine("GO");
      }

      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "SQL files|*.sql";
      sfd.Title = "Save the merged script";
      sfd.ShowDialog();
      // If the file name is not an empty string open it for saving.

      if (sfd.FileName != "")
      {
        File.WriteAllText(sfd.FileName, mergedScript.ToString());
      }
    }
  }
}