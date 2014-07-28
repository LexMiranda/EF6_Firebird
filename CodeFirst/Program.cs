using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace CodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ctx = new FirebirdContext())
			{
				var data = ctx.MONDatabase.First();
				Console.WriteLine("Name:{0}\t{1}", Environment.NewLine, data.DatabaseName);
				Console.WriteLine("CreationName:{0}\t{1}", Environment.NewLine, data.CreationDate);
			}
		}
	}
}
