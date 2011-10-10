using System;
using System.Windows.Forms;
using SiqualRunner.Core;
using SiqualRunner.Core.Entities;
using SiqualRunner.Core.Services;
using StructureMap;
using Undrtake.Infrastructure.Extensions;

namespace SiqualRunner
{
	public partial class DbServerSettings : BaseForm
	{
		private ISiqualConnection _siqualConnection;
		private readonly ISiqualConnectionManager _siqualConnectionManager = ObjectFactory.GetInstance<ISiqualConnectionManager>();

		public DatabaseServer DatabaseServer { get; private set; }

		public DbServerSettings(DatabaseServer dbServer)
		{
			InitializeComponent();
			DatabaseServer = dbServer ?? new DatabaseServer();

			InitializeControls();
		}

		private void InitializeControls()
		{
			txtServerAddress.Text = DatabaseServer.ServerAddress;
			lblServerAddress.Text = DatabaseServer.ServerAddress.IsEmpty() ? lblServerAddress.Text : DatabaseServer.ServerAddress;
			txtPassword.Text = DatabaseServer.Password;
			txtUserName.Text = DatabaseServer.UserName;
			txtDatabaseName.Text = DatabaseServer.DatabaseName;

			chkWindowsAuth.Checked = DatabaseServer.UseWindowsAuth;
		}

		private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
		{
			txtUserName.ReadOnly = txtPassword.ReadOnly = chkWindowsAuth.Checked;
		}

		private void txtServerAddress_KeyUp(object sender, KeyEventArgs e)
		{
			lblServerAddress.Text = txtServerAddress.Text;
		}

		private void lblServerAddress_TextChanged(object sender, EventArgs e)
		{
			lblServerAddress.Left = ((this.Width - lblServerAddress.Width) / 2);
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			DatabaseServer.ServerAddress = txtServerAddress.Text;
			DatabaseServer.Password = txtPassword.Text;
			DatabaseServer.UserName = txtUserName.Text;
			DatabaseServer.DatabaseName = txtDatabaseName.Text;
			DatabaseServer.UseWindowsAuth = chkWindowsAuth.Checked;

			DialogResult = DialogResult.OK;
		}

		private void btnTestConnection_Click(object sender, EventArgs e)
		{
			try
			{
				DatabaseServer tempServer = new DatabaseServer
				                            	{
				                            		ServerAddress = txtServerAddress.Text,
				                            		Password = txtPassword.Text,
				                            		UserName = txtUserName.Text,
				                            		DatabaseName = txtDatabaseName.Text,
				                            		UseWindowsAuth = chkWindowsAuth.Checked
				                            	};

				_siqualConnection = _siqualConnectionManager.CreateConnectionFor(tempServer);
				_siqualConnection.Open();
				_siqualConnection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			MessageBox.Show("Connection test successful.");
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
