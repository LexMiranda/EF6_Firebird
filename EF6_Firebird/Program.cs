using System;
using System.Data.Entity;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;

namespace EF6_Firebird
{
	class Program
	{
		static void Main(string[] args)
		{
			Database.SetInitializer<MyContext>(null);
			using (var ctx = new MyContext())
			{
				var data = ctx.MONDatabase.First();
				Console.WriteLine("Name:{0}\t{1}", Environment.NewLine, data.DatabaseName);
				Console.WriteLine("CreationName:{0}\t{1}", Environment.NewLine, data.CreationDate);
			}
		}
	}

	class MyContext : DbContext
	{
		public MyContext()
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

	class MONDatabase
	{
		public string DatabaseName { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
