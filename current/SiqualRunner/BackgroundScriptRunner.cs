using System.Collections.Generic;
using System.ComponentModel;
using SiqualRunner.Core;
using SiqualRunner.Core.Entities;
using StructureMap;

namespace SiqualRunner
{
	public class BackgroundScriptRunner
	{
		private IScriptRunner _scriptRunner;
		public event ProgressChangedEventHandler ProgressChanged = delegate { };

		readonly BackgroundWorker _worker = new BackgroundWorker();
		private bool _runAtomic;
		private DatabaseServer _server;
		private IList<SiqualFile> _scripts;

		public BackgroundScriptRunner()
		{
			_worker.DoWork += _worker_DoWork;
			_worker.WorkerReportsProgress = true;
			_worker.ProgressChanged += _worker_ProgressChanged;
			_worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
		}

		void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ProgressChanged(sender, new ProgressChangedEventArgs(100,e.UserState));
		}

		void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressChanged(sender, e);
		}

		void _scriptRunner_FileRan(object sender, FileRanEventHandlerArgs args)
		{
			_worker.ReportProgress(0, args);
		}

		void _worker_DoWork(object sender, DoWorkEventArgs e)
		{
			_scriptRunner = ObjectFactory.GetInstance<IScriptRunner>();
			_scriptRunner.FileRan += _scriptRunner_FileRan;

			if (_runAtomic) _scriptRunner.RunScriptsAtomic(_server, _scripts);
			else _scriptRunner.RunScripts(_server, _scripts);
		}

		public void RunNewScripts(DatabaseServer server, bool runAtomic)
		{
			IList<SiqualFile> notRanScripts = server.GetNotRanScripts();
			_runAtomic = runAtomic;
			_server = server;
			_scripts = notRanScripts;
			_worker.RunWorkerAsync();
		}

		public void RunScript(DatabaseServer server, int fileId, bool runAtomic)
		{
			SiqualFile notRanScript = server.GetScript(fileId);
			_runAtomic = runAtomic;
			_server = server;
			_scripts = new List<SiqualFile> { notRanScript };
			_worker.RunWorkerAsync();
		}

		public void RunScripts(DatabaseServer server, IList<int> fileIds, bool runAtomic)
		{
			IList<SiqualFile> notRanScript = server.GetScripts(fileIds);
			_runAtomic = runAtomic;
			_server = server;
			_scripts = notRanScript;
			_worker.RunWorkerAsync();
		}
	}
}