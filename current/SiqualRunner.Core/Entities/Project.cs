using System;
using System.Collections.Generic;
using System.Linq;
using Undrtake.Infrastructure.Entity;
using Undrtake.Infrastructure.Extensions;

namespace SiqualRunner.Core.Entities
{
	public class Project : EntityWithTypedId<int>
	{
		public virtual string FolderPath { get; set; }
		public virtual string ProjectName { get; set; }
		private IList<DatabaseServer> _servers;
		public virtual IList<DatabaseServer> Servers
		{
			get { return _servers ?? (_servers = new List<DatabaseServer>()); }
			set { _servers = value; }
		}

		public virtual void AddServer(DatabaseServer server)
		{
			if (Servers == null)
				Servers = new List<DatabaseServer>();

			Servers.Add(server);
		}

		public virtual void RemoveServer(DatabaseServer server)
		{
			DatabaseServer databaseServerToRemove = Servers.FirstOrDefault(x => x.Id == server.Id);
			if (databaseServerToRemove == null) throw new ArgumentOutOfRangeException("server","Server being removed did not belong to current project.");

			Servers.Remove(databaseServerToRemove);
		}

		public virtual void MakeDefaultServer(DatabaseServer server)
		{
			DatabaseServer databaseServer = Servers.FirstOrDefault(x => x.Id == server.Id);
			if (databaseServer == null) throw new ArgumentOutOfRangeException("server", "Server being removed did not belong to current project.");

			Servers.ForEach(x => x.IsDefault = false);
			databaseServer.IsDefault = true;
		}

		public virtual DatabaseServer GetDefaultDatabaseServer()
		{
			if(Servers.Count == 0) return null;

			DatabaseServer databaseServer = Servers.FirstOrDefault(x => x.IsDefault) ?? Servers[0];
			return databaseServer;
		}

	  public virtual bool HasAtLeasOnDBConfigured
	  {
	    get
	    {
	      return _servers != null && _servers.Count > 0;
	    }
	  }

		public override string ToString()
		{
			return ProjectName;
		} 
	}

	public class GeneralSettings : EntityWithTypedId<int>
	{
		//public virtual bool RunIn
	}
}
