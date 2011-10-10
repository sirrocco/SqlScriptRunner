using System;
using System.IO;
using System.Windows.Forms;
using SiqualRunner.Core.Entities;
using SiqualRunner.Core.Services;
using StructureMap;

namespace SiqualRunner
{
	public partial class FrmProjectSettings : BaseForm
	{
		private readonly IProjectService _projectService = ObjectFactory.GetInstance<IProjectService>();

		public Project Project { get; private set; }

		public FrmProjectSettings()
		{
			InitializeComponent();
		}

		public FrmProjectSettings(Project project)
			: this()
		{
			Project = project ?? new Project();

			InitializeControls();
		}

		private void InitializeControls()
		{
			InitializeEvents();
			txtProjectName.Text = Project.ProjectName;
			txtFolderPath.Text = Project.FolderPath;
			BindAvailableServerList();
		}

		private void InitializeEvents()
		{

			lstAvaialableServers.DataSourceChanged += new EventHandler(lstAvaialableServers_DataSourceChanged);
			lstAvaialableServers.SelectionMode = SelectionMode.One;
		}


		void lstAvaialableServers_DataSourceChanged(object sender, EventArgs e)
		{
			foreach (var item in lstAvaialableServers.Items)
			{
				DatabaseServer databaseServer = item as DatabaseServer;
				if (!databaseServer.IsDefault) continue;

				lstAvaialableServers.SelectedItem = databaseServer;
				break;
			}
		}

		private void BindAvailableServerList()
		{
			lstAvaialableServers.DataSource = null;
			lstAvaialableServers.DataSource = Project.Servers;
		}

		private void btnMakeDefaultServer_Click(object sender, EventArgs e)
		{
			DatabaseServer databaseServer = lstAvaialableServers.SelectedItem as DatabaseServer;
			if (databaseServer == null) return;

			Project.MakeDefaultServer(databaseServer);
			BindAvailableServerList();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Project.FolderPath = txtFolderPath.Text;
			Project.ProjectName = txtProjectName.Text;

			Cursor = Cursors.WaitCursor;

			using (NHTransaction)
			{
				_projectService.SaveProject(Project);
			}

			Cursor = Cursors.Default;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnChooseFolderPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.ShowNewFolderButton = false;
			DialogResult result = folderBrowserDialog1.ShowDialog();

			if (result != DialogResult.OK) return;
      
			Project.FolderPath = folderBrowserDialog1.SelectedPath;
			txtFolderPath.Text = Project.FolderPath;
		}

		private void btnAddSever_Click(object sender, EventArgs e)
		{
			DbServerSettings serverSettings = new DbServerSettings(null);
			DialogResult dialogResult = serverSettings.ShowDialog();

			if (dialogResult != DialogResult.OK) return;

			Project.AddServer(serverSettings.DatabaseServer);
			BindAvailableServerList();
		}

		private void btnDeleteServer_Click(object sender, EventArgs e)
		{
			DatabaseServer server = lstAvaialableServers.SelectedItem as DatabaseServer;
			if (server == null) return;

			Project.RemoveServer(server);
			BindAvailableServerList();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DatabaseServer selectedServer = lstAvaialableServers.SelectedItem as DatabaseServer;
			DbServerSettings serverSettings = new DbServerSettings(selectedServer);
			DialogResult dialogResult = serverSettings.ShowDialog();


			BindAvailableServerList();
		}
	}
}
