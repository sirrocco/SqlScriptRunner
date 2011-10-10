using System.Collections.Generic;
using SiqualRunner.Core.Entities;
using SiqualRunner.Core.Repositories;

namespace SiqualRunner.Core.Services
{
	public interface IDatabaseServerService
	{
		IList<SiqualFile> AddFileListToServer(IList<SiqualFile> files, DatabaseServer server);
		DatabaseServer Save(DatabaseServer server);
	}

	public class DatabaseServerService : IDatabaseServerService
	{
		private readonly IRepository<DatabaseServer> _databaseRepository;

		public DatabaseServerService(IRepository<DatabaseServer> databaseRepository)
		{
			_databaseRepository = databaseRepository;
		}

		public IList<SiqualFile> AddFileListToServer(IList<SiqualFile> files, DatabaseServer server)
		{
			server.AddFileRange(files);

			_databaseRepository.SaveOrUpdate(server);
			return files;
		}

		public DatabaseServer Save(DatabaseServer server)
		{
			_databaseRepository.SaveOrUpdate(server);
			return server;
		}
	}
}