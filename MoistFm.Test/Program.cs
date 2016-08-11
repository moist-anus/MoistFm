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
			var service = new LfmService("14e266cd3ede4e2eeb1a9fbd018b7eac");
			var user = new LfmUser("wrongnorw", service);
			user.GetInfo();

			Console.WriteLine($"{user.Name}");
			Console.WriteLine($"{user.RealName}");
			Console.WriteLine($"{user.Playcount}");

			user.GetNowPlaying();

			Console.WriteLine($"{user.NowPlaying.Artist.Name} {user.NowPlaying.Name}");

			Console.WriteLine();
			Console.WriteLine("done.");
			Console.ReadKey();
		}
	}
}
