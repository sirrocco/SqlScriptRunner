using System;
using NHibernate;
using SiqualRunner.Core.Entities;
using Undrtake.Infrastructure.Persistence;
using Undrtake.Infrastructure.Repository;

namespace SiqualRunner.Core.Repositories
{
	public interface IProjectRepository : IBaseRepo<Project, int>
	{
		Project LoadProjectById(int id);
	}

	public class ProjectRepository : BaseRepository<Project, int, ProjectRepository>, IProjectRepository
	{
		public ProjectRepository(INHUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}


		public Project LoadProjectById(int id)
		{
			Init().ByIdInner(id);
			_criteria.SetFetchMode("Servers", FetchMode.Eager);
			return LoadEntity();
		}
	}
}