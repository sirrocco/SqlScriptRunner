using Undrtake.Infrastructure.Persistence;
using Undrtake.Infrastructure.Repository;

namespace SiqualRunner.Core.Repositories
{
	public interface IRepository<T>:IBaseRepo<T,int>
	{
		
	}

	public class Repository<T> : BaseRepository<T, int, Repository<T>>, IRepository<T>
	{
		public Repository(INHUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}
	}
}