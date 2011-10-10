using System;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Core
{
	public interface ISiqualConnectionManager
	{
		ISiqualConnection CreateConnectionFor(DatabaseServer server);
	}

	public class SiqualConnectionManager : ISiqualConnectionManager
	{
		public ISiqualConnection CreateConnectionFor(DatabaseServer server)
		{
			SiqualConnection connection = new SiqualConnection(server);
			//connection.Open();
			return connection;
		}
	}
}