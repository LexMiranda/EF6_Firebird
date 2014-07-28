using System.Data.Entity;

namespace CodeFirst
{
	class FirebirdContextConfiguration : DbConfiguration
	{
		public FirebirdContextConfiguration()
		{
			SetDatabaseInitializer<FirebirdContext>(null);
		}
	}
}
