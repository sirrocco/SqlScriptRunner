using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Undrtake.Infrastructure.Entity;

namespace SiqualRunner.Core.Entities
{
	public class SiqualFile : EntityWithTypedId<int>
	{
		private IList<DatabaseServer> _assignedDBServers;
		private IList<FileStatus> _fileStatuses;

		public SiqualFile() { }

		public SiqualFile(string path, DatabaseServer server, Project project)
			: this()
		{
			AssignedDbServers.Add(server);
			FullFilePath = path;
			BelongsToProject = project;
			FileStatuses.Add(new FileStatus
												{
													RunStatus = EnumRunStatus.NotRan,
													RanFor = server
												});


		}


		public virtual IList<DatabaseServer> AssignedDbServers
		{
			get { return _assignedDBServers ?? (_assignedDBServers = new List<DatabaseServer>()); }
			set { _assignedDBServers = value; }
		}

		public virtual string FullFilePath { get; set; }

		public virtual string FileName
		{
			get
			{
				return Path.GetFileName(FullFilePath);
			}
		}

		public virtual Project BelongsToProject { get; set; }

		public virtual IList<FileStatus> FileStatuses
		{
			get { return _fileStatuses ?? (_fileStatuses = new List<FileStatus>()); }
			set { _fileStatuses = value; }
		}

		public virtual void AddFileStatus(FileStatus status)
		{
			if (FileStatuses == null)
				FileStatuses = new List<FileStatus>();
			FileStatuses.Add(status);
		}

		public virtual FileStatus SaveStatusFor(DatabaseServer server, EnumRunStatus status, string message)
		{
			FileStatus fileStatus = FileStatuses.FirstOrDefault(x => x.RanFor.Id == server.Id) ?? new FileStatus();
			fileStatus.ErrorMessage = message;
			fileStatus.RunStatus = status;
			fileStatus.RanFor = server;
			fileStatus.RunTime = new TimeSpan();

			if (fileStatus.Id == 0)
				FileStatuses.Add(fileStatus);

			return fileStatus;
		}

		public virtual FileStatus SaveStatusFor(DatabaseServer server, EnumRunStatus status, TimeSpan executionDuration)
		{
			FileStatus fileStatus = FileStatuses.FirstOrDefault(x => x.RanFor.Id == server.Id) ?? new FileStatus();
			fileStatus.RunStatus = status;
			fileStatus.RanFor = server;
			fileStatus.RunTime = executionDuration;
			fileStatus.ErrorMessage = "";

			if(fileStatus.Id == 0)
				FileStatuses.Add(fileStatus);

			return fileStatus;
		}
	}
}