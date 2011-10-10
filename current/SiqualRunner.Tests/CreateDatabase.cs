using FluentNHibernate;
using NUnit.Framework;
using SiqualRunner.Core.Entities.mappings;

namespace SiqualRunner.Tests
{
	[TestFixture]
	public class CreateDatabase
	{
		[Test]
		public void Create()
		{
			ISessionSource s = new SessionSource(new SQLRPersistenceModel());
			s.BuildSchema();
		}
	}
}