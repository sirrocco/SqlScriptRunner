using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Core
{
	public interface IScriptRunner
	{
		void RunScripts(DatabaseServer server, IList<SiqualFile> scripts);
		void RunScriptsAtomic(DatabaseServer server, IList<SiqualFile> scripts);
		event FileRanEventHandler FileRan;
	}

	public class ScriptRunner : IScriptRunner
	{
		private readonly ISiqualConnectionManager _siqualConnectionManager;
		private DatabaseServer _server;
		private bool _runAtomic;

		public ScriptRunner(ISiqualConnectionManager siqualConnectionManager)
		{
			_siqualConnectionManager = siqualConnectionManager;
		}

		public void RunScripts(DatabaseServer server, IList<SiqualFile> scripts)
		{
			_server = server;
			using (ISiqualConnection connection = _siqualConnectionManager.CreateConnectionFor(server))
			{
				connection.Open();
				RunScriptsInternal(server, scripts, connection);
			}
		}

		public void RunScriptsAtomic(DatabaseServer server, IList<SiqualFile> scripts)
		{
			_runAtomic = true;
			using (ISiqualConnection connection = _siqualConnectionManager.CreateConnectionFor(server))
			{
				try
				{
					connection.Open();
					connection.BeginTransaction();

					RunScriptsInternal(server, scripts, connection);

					connection.Commit();

				}
				catch
				{
					connection.Rollback();
				}
			}
		}

		public event FileRanEventHandler FileRan = delegate { };

		private void RunScriptsInternal(DatabaseServer server, IEnumerable<SiqualFile> files, ISiqualConnection connection)
		{
			_server = server;

			foreach (SiqualFile file in files)
			{
				RunScriptWithStatistics(file, connection);
			}
		}

		private void RunScriptWithStatistics(SiqualFile file, ISiqualConnection connection)
		{
			Stopwatch timer = new Stopwatch();
			timer.Start();

			EnumRunStatus status = ExecuteScript(file, connection);

			timer.Stop();

			if (status == EnumRunStatus.Success)
				file.SaveStatusFor(_server, status, timer.Elapsed);

			FileRan(this, new FileRanEventHandlerArgs(file));
		}

		private EnumRunStatus ExecuteScript(SiqualFile file, ISiqualConnection connection)
		{
			string sqlScript = File.ReadAllText(file.FullFilePath);

			try
			{
				connection.Execute(sqlScript);
			}
			catch (Exception ex)
			{
				string exceptionMessage = RecursiveDrillToException(typeof(SqlException), ex);
				file.SaveStatusFor(_server, EnumRunStatus.Fail, exceptionMessage);
				if (_runAtomic)
					throw;

				return EnumRunStatus.Fail;
			}

			return EnumRunStatus.Success;
		}

		private string RecursiveDrillToException(Type exType, Exception ex)
		{
			if (ex.GetType() == exType)
				return ex.Message;

			if (ex.InnerException == null)
				return "";

			return RecursiveDrillToException(exType, ex.InnerException);
		}
	}
}