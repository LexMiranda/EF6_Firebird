using System.Data.Entity;
using FirebirdSql.Data.FirebirdClient;

namespace CodeFirst
{
	[DbConfigurationType(typeof(FirebirdContextConfiguration))]
	class FirebirdContext : DbContext
	{
		public FirebirdContext()
			: base(new FbConnection(@"database=localhost:test.fdb;user=sysdba;password=masterkey"), true)
		{ }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var monDatabaseConfiguration = modelBuilder.Entity<MONDatabase>();
			monDatabaseConfiguration.HasKey(x => x.DatabaseName);
			monDatabaseConfiguration.Property(x => x.DatabaseName).HasColumnName("MON$DATABASE_NAME");
			monDatabaseConfiguration.Property(x => x.CreationDate).HasColumnName("MON$CREATION_DATE");
			monDatabaseConfiguration.ToTable("MON$DATABASE");
		}

		public DbSet<MONDatabase> MONDatabase { get; set; }
	}
}
