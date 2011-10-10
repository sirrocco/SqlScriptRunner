using FluentNHibernate.Mapping;

namespace SiqualRunner.Core.Entities.mappings
{
	public class ProjectMap : ClassMap<Project>
	{
		public ProjectMap()
		{
			Id(x => x.Id).GeneratedBy.HiLo("2048");
			Map(x => x.FolderPath).WithLengthOf(500).Not.Nullable();
			Map(x => x.ProjectName).WithLengthOf(150).Not.Nullable();
      
			HasMany(x => x.Servers).AsBag().Not.LazyLoad().Cascade.AllDeleteOrphan();
		}
	}

	public class DatabaseServerMap : ClassMap<DatabaseServer>
	{
		public DatabaseServerMap()
		{
			Id(x => x.Id).GeneratedBy.HiLo("2048");
			Map(x => x.UserName).WithLengthOf(100);
			Map(x => x.Password).WithLengthOf(300);
			Map(x => x.ServerAddress).WithLengthOf(50);
			Map(x => x.DatabaseName).WithLengthOf(50);
			Map(x => x.UseWindowsAuth);
			Map(x => x.IsDefault);

			HasManyToMany(x => x.Files).AsBag().Cascade.AllDeleteOrphan();
		}
	}

	public class SiqualFileMap : ClassMap<SiqualFile>
	{
		public SiqualFileMap()
		{
			Id(x => x.Id).GeneratedBy.HiLo("2048");
			Map(x => x.FullFilePath).WithLengthOf(500);

			HasManyToMany(x => x.AssignedDbServers).LazyLoad().AsBag();
			References(x => x.BelongsToProject).Not.Nullable().LazyLoad();

			HasMany(x => x.FileStatuses).AsBag().Not.LazyLoad().Cascade.AllDeleteOrphan();
		}
	}

	public class FileStatusMap :ClassMap<FileStatus>
	{
		public FileStatusMap()
		{
			Id(x => x.Id).GeneratedBy.HiLo("2048");
			Map(x => x.RanOn).Not.Nullable();
      Map(x => x.RunTime).Not.Nullable();
			Map(x => x.ErrorMessage).WithLengthOf(1000);
			Map(x => x.RunStatus).CustomTypeIs(typeof (EnumRunStatus)).Not.Nullable();

			References(x => x.RanFor).Not.Nullable();


		}
	}
}