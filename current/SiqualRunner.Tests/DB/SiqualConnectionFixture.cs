using NUnit.Framework;
using SiqualRunner.Core;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Tests.DB
{
	[TestFixture]
	public class SiqualConnectionFixture
	{
		[Test]
		public void After_connection_is_opened_status_is_opened()
		{
			const DatabaseServer databaseServer = null;
			ISiqualConnection siqualConnection = new SiqualConnection(databaseServer);
			siqualConnection.Open();

			Assert.IsTrue(siqualConnection.IsOpened);
		}

		[Test]
		public void After_disposing_connection_is_closed()
		{
			const DatabaseServer databaseServer = null;
			ISiqualConnection siqualConnection;
			using (siqualConnection = new SiqualConnection(databaseServer)) { }

			Assert.IsFalse(siqualConnection.IsOpened);
		}

	}
}