using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using SiqualRunner.Core;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Tests.DB
{
	[TestFixture]
	public class ScriptRunnerFixture
	{
		private ISiqualConnectionManager _siqualConnectionManager;
		private ISiqualConnection _siqualConnection;

		[SetUp]
		public void Setup()
		{
			_siqualConnectionManager = MockRepository.GenerateMock<ISiqualConnectionManager>();
			_siqualConnection = MockRepository.GenerateMock<ISiqualConnection>();
		}

		[Test]
		[Ignore]
		public void When_file_is_ran_event_is_launched()
		{
			//DatabaseServer databaseServer = CreateDBServer();

			//IScriptRunner scriptRunner = new ScriptRunner(_siqualConnectionManager);

			//IList<SiqualFile> fileList = GetFiles();

			//scriptRunner.RunScripts(databaseServer, fileList);

			//_siqualConnectionManager.VerifyAllExpectations();

		}

		[Test]
		public void For_atomic_operations_transaction_is_used()
		{
			DatabaseServer databaseServer = CreateDBServer();

			_siqualConnectionManager.Expect(x => x.CreateConnectionFor(null)).IgnoreArguments().Return(_siqualConnection);
			_siqualConnection.Expect(x => x.BeginTransaction()).IgnoreArguments();
			_siqualConnection.Expect(x => x.Commit()).IgnoreArguments();

			IScriptRunner scriptRunner = new ScriptRunner(_siqualConnectionManager);

			IList<SiqualFile> fileList = GetFiles();

			scriptRunner.RunScriptsAtomic(databaseServer, fileList);

			_siqualConnectionManager.VerifyAllExpectations();
		}

		[Test]
		public void After_script_ran_file_status_is_set()
		{
			DatabaseServer databaseServer = CreateDBServer();

			_siqualConnectionManager.Expect(x => x.CreateConnectionFor(null)).IgnoreArguments().Return(new SiqualConnection(databaseServer));
			IScriptRunner scriptRunner = new ScriptRunner(_siqualConnectionManager);

			IList<SiqualFile> fileList = GetFiles();

			scriptRunner.RunScripts(databaseServer, fileList);

			_siqualConnectionManager.VerifyAllExpectations();
			foreach (SiqualFile file in fileList)
			{
				Assert.That(file.FileStatuses.Count, Is.Not.EqualTo(0));
				FileStatus fileStatus = file.FileStatuses.FirstOrDefault(f => f.RanFor == databaseServer);

				Assert.That(fileStatus, Is.Not.Null);
				Assert.That(fileStatus.RunTime, Is.Not.Null);
			}
		}

		private DatabaseServer CreateDBServer()
		{
			return new DatabaseServer
			       	{
			       		Files = GetFiles()
			       	};
		}

		private IList<SiqualFile> GetFiles()
		{
			return new List<SiqualFile>
			       	{
			       		new SiqualFile{},
			       		new SiqualFile{}
			       	};
		}
	}
}