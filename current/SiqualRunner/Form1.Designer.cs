namespace SiqualRunner
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.mnMainMenu = new System.Windows.Forms.MenuStrip();
      this.btnNewProject = new System.Windows.Forms.ToolStripMenuItem();
      this.btnLoadProject = new System.Windows.Forms.ToolStripMenuItem();
      this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlProjectList = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.lstProjects = new System.Windows.Forms.ListBox();
      this.contextMenuStripProjectList = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.stripEditProject = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlFileList = new System.Windows.Forms.Panel();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new SiqualRunner.StatusMessageLabel();
      this.chkRunAtomic = new System.Windows.Forms.CheckBox();
      this.btnRunScripts = new System.Windows.Forms.Button();
      this.gvFileList = new System.Windows.Forms.DataGridView();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.stripOpenFile = new System.Windows.Forms.ToolStripMenuItem();
      this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stripSyncFilesFromFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mRunSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnMergeAll = new System.Windows.Forms.ToolStripMenuItem();
      this.mnMainMenu.SuspendLayout();
      this.pnlProjectList.SuspendLayout();
      this.contextMenuStripProjectList.SuspendLayout();
      this.pnlFileList.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // mnMainMenu
      // 
      this.mnMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewProject,
            this.btnLoadProject,
            this.btnMergeAll,
            this.btnExit});
      this.mnMainMenu.Location = new System.Drawing.Point(0, 0);
      this.mnMainMenu.Name = "mnMainMenu";
      this.mnMainMenu.Size = new System.Drawing.Size(575, 24);
      this.mnMainMenu.TabIndex = 0;
      this.mnMainMenu.Text = "menuStrip1";
      // 
      // btnNewProject
      // 
      this.btnNewProject.Name = "btnNewProject";
      this.btnNewProject.Size = new System.Drawing.Size(83, 20);
      this.btnNewProject.Text = "New Project";
      this.btnNewProject.Click += new System.EventHandler(this.BtnNewProjectClick);
      // 
      // btnLoadProject
      // 
      this.btnLoadProject.Name = "btnLoadProject";
      this.btnLoadProject.Size = new System.Drawing.Size(85, 20);
      this.btnLoadProject.Text = "Load Project";
      this.btnLoadProject.Click += new System.EventHandler(this.BtnLoadProjectClick);
      // 
      // btnExit
      // 
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(37, 20);
      this.btnExit.Text = "Exit";
      this.btnExit.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
      // 
      // pnlProjectList
      // 
      this.pnlProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlProjectList.Controls.Add(this.label1);
      this.pnlProjectList.Controls.Add(this.lstProjects);
      this.pnlProjectList.Location = new System.Drawing.Point(0, 27);
      this.pnlProjectList.Name = "pnlProjectList";
      this.pnlProjectList.Size = new System.Drawing.Size(575, 322);
      this.pnlProjectList.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(157, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(156, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Double click a project to load it.";
      // 
      // lstProjects
      // 
      this.lstProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lstProjects.BackColor = System.Drawing.Color.LightYellow;
      this.lstProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lstProjects.ContextMenuStrip = this.contextMenuStripProjectList;
      this.lstProjects.FormattingEnabled = true;
      this.lstProjects.Location = new System.Drawing.Point(0, 16);
      this.lstProjects.Name = "lstProjects";
      this.lstProjects.Size = new System.Drawing.Size(572, 299);
      this.lstProjects.TabIndex = 0;
      this.lstProjects.DoubleClick += new System.EventHandler(this.lstProjects_DoubleClick);
      // 
      // contextMenuStripProjectList
      // 
      this.contextMenuStripProjectList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripEditProject});
      this.contextMenuStripProjectList.Name = "contextMenuStripProjectList";
      this.contextMenuStripProjectList.Size = new System.Drawing.Size(95, 26);
      // 
      // stripEditProject
      // 
      this.stripEditProject.Name = "stripEditProject";
      this.stripEditProject.Size = new System.Drawing.Size(94, 22);
      this.stripEditProject.Text = "Edit";
      this.stripEditProject.Click += new System.EventHandler(this.StripEditProjectClick);
      // 
      // pnlFileList
      // 
      this.pnlFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlFileList.Controls.Add(this.statusStrip);
      this.pnlFileList.Controls.Add(this.chkRunAtomic);
      this.pnlFileList.Controls.Add(this.btnRunScripts);
      this.pnlFileList.Controls.Add(this.gvFileList);
      this.pnlFileList.Location = new System.Drawing.Point(0, 24);
      this.pnlFileList.Name = "pnlFileList";
      this.pnlFileList.Size = new System.Drawing.Size(575, 350);
      this.pnlFileList.TabIndex = 2;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 328);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(575, 22);
      this.statusStrip.TabIndex = 3;
      this.statusStrip.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(544, 17);
      this.statusLabel.Text = "Do you suffer from ADHD? Me eith- oh look a bunny What was I doing again? Oh, rig" +
          "ht. Here we go....";
      // 
      // chkRunAtomic
      // 
      this.chkRunAtomic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkRunAtomic.AutoSize = true;
      this.chkRunAtomic.Location = new System.Drawing.Point(275, 305);
      this.chkRunAtomic.Name = "chkRunAtomic";
      this.chkRunAtomic.Size = new System.Drawing.Size(113, 17);
      this.chkRunAtomic.TabIndex = 2;
      this.chkRunAtomic.Text = "Run scripts atomic";
      this.chkRunAtomic.UseVisualStyleBackColor = true;
      // 
      // btnRunScripts
      // 
      this.btnRunScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnRunScripts.Location = new System.Drawing.Point(81, 301);
      this.btnRunScripts.Name = "btnRunScripts";
      this.btnRunScripts.Size = new System.Drawing.Size(188, 23);
      this.btnRunScripts.TabIndex = 1;
      this.btnRunScripts.Text = "Run Scripts";
      this.btnRunScripts.UseVisualStyleBackColor = true;
      this.btnRunScripts.Click += new System.EventHandler(this.BtnRunScriptsClick);
      // 
      // gvFileList
      // 
      this.gvFileList.AllowUserToAddRows = false;
      this.gvFileList.AllowUserToDeleteRows = false;
      this.gvFileList.AllowUserToResizeColumns = false;
      this.gvFileList.AllowUserToResizeRows = false;
      this.gvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gvFileList.BackgroundColor = System.Drawing.SystemColors.Info;
      this.gvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gvFileList.ContextMenuStrip = this.contextMenuStrip1;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.gvFileList.DefaultCellStyle = dataGridViewCellStyle1;
      this.gvFileList.GridColor = System.Drawing.SystemColors.Info;
      this.gvFileList.Location = new System.Drawing.Point(3, 3);
      this.gvFileList.Name = "gvFileList";
      this.gvFileList.ReadOnly = true;
      this.gvFileList.RowHeadersVisible = false;
      this.gvFileList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.gvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gvFileList.Size = new System.Drawing.Size(569, 292);
      this.gvFileList.TabIndex = 0;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripOpenFile,
            this.openDirectoryToolStripMenuItem,
            this.stripSyncFilesFromFolder,
            this.mToolStripMenuItem,
            this.mRunSelected});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(186, 114);
      // 
      // stripOpenFile
      // 
      this.stripOpenFile.Name = "stripOpenFile";
      this.stripOpenFile.Size = new System.Drawing.Size(185, 22);
      this.stripOpenFile.Text = "Open File";
      this.stripOpenFile.Click += new System.EventHandler(this.StripOpenFileClick);
      // 
      // openDirectoryToolStripMenuItem
      // 
      this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
      this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
      this.openDirectoryToolStripMenuItem.Text = "Open Directory";
      this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectoryToolStripMenuItemClick);
      // 
      // stripSyncFilesFromFolder
      // 
      this.stripSyncFilesFromFolder.Name = "stripSyncFilesFromFolder";
      this.stripSyncFilesFromFolder.Size = new System.Drawing.Size(185, 22);
      this.stripSyncFilesFromFolder.Text = "Refresh file list";
      this.stripSyncFilesFromFolder.Click += new System.EventHandler(this.StripSyncFilesFromFolderClick);
      // 
      // mToolStripMenuItem
      // 
      this.mToolStripMenuItem.Name = "mToolStripMenuItem";
      this.mToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
      this.mToolStripMenuItem.Text = "Mark Selected as Ran";
      this.mToolStripMenuItem.Click += new System.EventHandler(this.MToolStripMenuItemClick);
      // 
      // mRunSelected
      // 
      this.mRunSelected.Name = "mRunSelected";
      this.mRunSelected.Size = new System.Drawing.Size(185, 22);
      this.mRunSelected.Text = "Run";
      this.mRunSelected.Click += new System.EventHandler(this.MRunSelectedClick);
      // 
      // notifyIcon
      // 
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Sql Script Runner";
      this.notifyIcon.Visible = true;
      // 
      // toolTip1
      // 
      this.toolTip1.ShowAlways = true;
      // 
      // btnMergeAll
      // 
      this.btnMergeAll.Name = "btnMergeAll";
      this.btnMergeAll.Size = new System.Drawing.Size(108, 20);
      this.btnMergeAll.Text = "Merge All Scripts";
      this.btnMergeAll.Click += new System.EventHandler(this.BtnMergeAllClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(575, 374);
      this.Controls.Add(this.mnMainMenu);
      this.Controls.Add(this.pnlFileList);
      this.Controls.Add(this.pnlProjectList);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.mnMainMenu;
      this.Name = "Form1";
      this.Text = "Run that script";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1KeyUp);
      this.mnMainMenu.ResumeLayout(false);
      this.mnMainMenu.PerformLayout();
      this.pnlProjectList.ResumeLayout(false);
      this.pnlProjectList.PerformLayout();
      this.contextMenuStripProjectList.ResumeLayout(false);
      this.pnlFileList.ResumeLayout(false);
      this.pnlFileList.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnMainMenu;
		private System.Windows.Forms.Panel pnlProjectList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstProjects;
		private System.Windows.Forms.Panel pnlFileList;
		private System.Windows.Forms.DataGridView gvFileList;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem stripOpenFile;
		private System.Windows.Forms.ToolStripMenuItem stripSyncFilesFromFolder;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripProjectList;
		private System.Windows.Forms.ToolStripMenuItem stripEditProject;
		private System.Windows.Forms.Button btnRunScripts;
		private System.Windows.Forms.CheckBox chkRunAtomic;
		private System.Windows.Forms.StatusStrip statusStrip;
		private StatusMessageLabel statusLabel;
		private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
    private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem mRunSelected;
		private System.Windows.Forms.ToolStripMenuItem btnNewProject;
		private System.Windows.Forms.ToolStripMenuItem btnLoadProject;
		private System.Windows.Forms.ToolStripMenuItem btnExit;
    private System.Windows.Forms.ToolStripMenuItem btnMergeAll;
	}
}

