using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public class LfmAlbumContext : LfmContext
	{
		public LfmAlbumContext(string name, string artist, LfmService service)
			: this(service)
		{
			Name = name;
			Artist = artist;
		}

		public LfmAlbumContext(LfmService service)
			: base(service)
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&artist={WebUtility.UrlEncode(Artist)}&album={WebUtility.UrlEncode(Name)}"; } }

		public string Name { get; set; } = string.Empty;

		public string Artist { get; set; } = string.Empty;

		private LfmAlbumMap AlbumMap { get; set; } = new LfmAlbumMap();

		public void GetInfo(LfmAlbum mapTo)
		{
			var album = GetInfo();
			AlbumMap.Map(album, mapTo);
		}

		public LfmAlbum GetInfo()
		{
			Method = "album.getinfo";
			ProcessRequest();

			var album = AlbumMap.Map(Response.SelectSingleNode("/lfm/album"));
			album.Service = Service;
			album.Service.AlbumContext.Name = album.Name;
			album.Service.AlbumContext.Artist = album.Artist.Name;

			return album;
		}
	}
}
