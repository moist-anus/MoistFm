using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Models;

namespace MoistFm.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new LfmService("f362112c9bc1fdead65441f44a8daa57");
			var user = new LfmUser("wrongnorw", service);
			user.GetNowPlaying();

			Console.WriteLine($"{user.NowPlaying.Artist.Name} {user.NowPlaying.Name}");

			Console.WriteLine();
			Console.WriteLine("done.");
			Console.ReadKey();
		}
	}
}
