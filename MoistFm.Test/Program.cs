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

			user.GetNowPlaying();
			user.NowPlaying.GetInfo();
			Console.WriteLine($"{user.NowPlaying.Artist.Name} {user.NowPlaying.Name} {user.NowPlaying.Length.Minutes} {user.NowPlaying.Length.Seconds}");

			Console.WriteLine();
			Console.WriteLine("done.");
			Console.ReadKey();
		}
	}
}
