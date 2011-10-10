using SiqualRunner.Core.Entities;

namespace SiqualRunner
{
	public class SiqualRunnerContext
	{
		public static Project CurrentProject { get; set; }
		public static DatabaseServer SelectedServer
		{
			get
			{
				return CurrentProject == null ? null : CurrentProject.GetDefaultDatabaseServer();
			}
		}
	}
}