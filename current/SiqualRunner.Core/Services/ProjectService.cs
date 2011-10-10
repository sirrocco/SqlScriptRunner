using SiqualRunner.Core.Entities;
using SiqualRunner.Core.Repositories;

namespace SiqualRunner.Core.Services
{
	public interface IProjectService
	{
		Project SaveProject(Project project);
		DatabaseServer AddServerToProject(string serverAddress, string userName, string password, bool useWindowsAuth,Project existingProject);
	}

	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public Project SaveProject(Project project)
		{

			// validate project

			_projectRepository.SaveOrUpdate(project);
			return project;
		}

		public DatabaseServer AddServerToProject(string serverAddress, string userName, string password, bool useWindowsAuth,Project existingProject)
		{
			DatabaseServer server = new DatabaseServer
			                        	{
			                        		Password = password,
			                        		ServerAddress = serverAddress,
			                        		UserName = userName,
			                        		UseWindowsAuth = useWindowsAuth
			                        	};
			existingProject.AddServer(server);
			_projectRepository.SaveOrUpdate(existingProject);

			return server;
		}
	}
}