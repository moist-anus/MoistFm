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
			var tracks = user.GetLovedTracks();

			foreach (var track in tracks)
			{
				Console.WriteLine($"{track.Artist.Name} - {track.Name}");
			}

			//Console.WriteLine($"{nowplaying.Artist.Name} - {nowplaying.Name} from {nowplaying.Album.Name}");
			//var album = new LfmAlbum("Believe", "Cher");
			//var albumInfo = album.GetInfo();

			//Console.WriteLine($"{albumInfo.Artist.Name} - {albumInfo.Name}");
			//Console.WriteLine($"{albumInfo.Url}");

			//foreach (var image in albumInfo.Images)
			//{
			//	Console.WriteLine($"{image.Size} - {image.Url}");
			//}

			//Console.WriteLine($"{albumInfo.Stats.Listeners}");
			//Console.WriteLine($"{albumInfo.Stats.Playcount}");

			//foreach (var track in albumInfo.Tracks)
			//{
			//	Console.WriteLine($"{track.Name}");
			//}

			//foreach (var tag in albumInfo.Tags)
			//{
			//	Console.WriteLine($"{tag.Name}");
			//}

			//Console.WriteLine($"{albumInfo.Wiki.Published}");
			//Console.WriteLine($"{albumInfo.Wiki.Summary}");
			//Console.WriteLine($"{albumInfo.Wiki.Content}");

			Console.WriteLine();
			Console.WriteLine("done.");
			Console.ReadKey();
		}
	}
}
