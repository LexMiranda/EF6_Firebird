using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDMX
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ctx = new FirebirdContainer())
			{
				foreach (var item in ctx.TESTs)
				{
					Console.WriteLine(item.ID);
				}
			}
		}
	}
}
