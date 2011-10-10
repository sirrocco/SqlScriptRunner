namespace SiqualRunner
{
	partial class DbServerSettings
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
			this.lblServerAddress = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtServerAddress = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkWindowsAuth = new System.Windows.Forms.CheckBox();
			this.btnTestConnection = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtDatabaseName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblServerAddress
			// 
			this.lblServerAddress.AutoSize = true;
			this.lblServerAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblServerAddress.Location = new System.Drawing.Point(86, 0);
			this.lblServerAddress.Name = "lblServerAddress";
			this.lblServerAddress.Size = new System.Drawing.Size(112, 13);
			this.lblServerAddress.TabIndex = 0;
			this.lblServerAddress.Text = "- Server Name -";
			this.lblServerAddress.TextChanged += new System.EventHandler(this.lblServerAddress_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Address: ";
			// 
			// txtServerAddress
			// 
			this.txtServerAddress.Location = new System.Drawing.Point(70, 48);
			this.txtServerAddress.MaxLength = 100;
			this.txtServerAddress.Name = "txtServerAddress";
			this.txtServerAddress.Size = new System.Drawing.Size(202, 20);
			this.txtServerAddress.TabIndex = 0;
			this.txtServerAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtServerAddress_KeyUp);
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(70, 100);
			this.txtUserName.MaxLength = 100;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(202, 20);
			this.txtUserName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "User: ";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(70, 126);
			this.txtPassword.MaxLength = 100;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(202, 20);
			this.txtPassword.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Password: ";
			// 
			// chkWindowsAuth
			// 
			this.chkWindowsAuth.AutoSize = true;
			this.chkWindowsAuth.Location = new System.Drawing.Point(70, 152);
			this.chkWindowsAuth.Name = "chkWindowsAuth";
			this.chkWindowsAuth.Size = new System.Drawing.Size(163, 17);
			this.chkWindowsAuth.TabIndex = 4;
			this.chkWindowsAuth.Text = "Use Windows Authentication";
			this.chkWindowsAuth.UseVisualStyleBackColor = true;
			this.chkWindowsAuth.CheckedChanged += new System.EventHandler(this.chkWindowsAuth_CheckedChanged);
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTestConnection.Location = new System.Drawing.Point(78, 175);
			this.btnTestConnection.Name = "btnTestConnection";
			this.btnTestConnection.Size = new System.Drawing.Size(128, 23);
			this.btnTestConnection.TabIndex = 5;
			this.btnTestConnection.Text = "Test Connection";
			this.btnTestConnection.UseVisualStyleBackColor = true;
			this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(153, 227);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(128, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Continue";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(8, 227);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtDatabaseName
			// 
			this.txtDatabaseName.Location = new System.Drawing.Point(70, 74);
			this.txtDatabaseName.MaxLength = 100;
			this.txtDatabaseName.Name = "txtDatabaseName";
			this.txtDatabaseName.Size = new System.Drawing.Size(202, 20);
			this.txtDatabaseName.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 77);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Database: ";
			// 
			// DbServerSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.txtDatabaseName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnTestConnection);
			this.Controls.Add(this.chkWindowsAuth);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtServerAddress);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblServerAddress);
			this.Name = "DbServerSettings";
			this.Text = "Database Server Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblServerAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtServerAddress;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkWindowsAuth;
		private System.Windows.Forms.Button btnTestConnection;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtDatabaseName;
		private System.Windows.Forms.Label label4;
	}
}