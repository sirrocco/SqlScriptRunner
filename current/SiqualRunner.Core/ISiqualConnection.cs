using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

using SiqualRunner.Core.Entities;

namespace SiqualRunner.Core
{
	public interface ISiqualConnection : IDisposable
	{
		void Open();
		void BeginTransaction();
		void Commit();
		void Rollback();
		void Close();
		bool IsOpened { get; }
		void Execute(string script);
	}

	public class SiqualConnection : ISiqualConnection
	{
		private readonly DatabaseServer _server;
		private bool _isDisposed;

		private ServerConnection _smoConnection;
		public SiqualConnection(DatabaseServer server)
		{
			_server = server;
		}

		public void Open()
		{
		  SqlConnectionInfo smoConn = new SqlConnectionInfo
												{
													UserName = _server.UserName,
													Password = _server.Password,
													UseIntegratedSecurity = _server.UseWindowsAuth,
													ServerName = _server.ServerAddress
												};
			
			_smoConnection = new ServerConnection(smoConn);
			_smoConnection.DatabaseName = _server.DatabaseName;

			_smoConnection.Connect();

			IsOpened = true;
		}

		public void BeginTransaction()
		{
			_smoConnection.BeginTransaction();
		}

		public void Commit()
		{
			_smoConnection.CommitTransaction();
		}

		public void Rollback()
		{
			_smoConnection.RollBackTransaction();
		}

		public void Close()
		{
			_smoConnection.Disconnect();
			IsOpened = false;
		}

		public bool IsOpened { get; private set; }

		public void Execute(string script)
		{
			_smoConnection.ExecuteNonQuery(script);
		}

		public void Dispose()
		{
			if (_isDisposed)
				return;

			Close();
			_isDisposed = true;

		}
	}
}