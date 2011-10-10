using NUnit.Framework;
using SiqualRunner.Core;

namespace SiqualRunner.Tests.DB
{
	[TestFixture]
	public class SiqualConnectionManagerFixture
	{
		[Test]
		public void When_creating_new_connection_the_connection_is_opened()
		{
			ISiqualConnectionManager connectionManager = new SiqualConnectionManager();
			ISiqualConnection connection = connectionManager.CreateConnectionFor(null);

			Assert.IsTrue(connection.IsOpened);
		}
	}
}