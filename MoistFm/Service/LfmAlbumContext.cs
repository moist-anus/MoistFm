using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public class LfmAlbumContext : LfmContext
	{
		public LfmAlbumContext(string name, string artist, string apiKey)
			: this(apiKey)
		{
			Name = name;
			Artist = artist;
		}

		public LfmAlbumContext(string apiKey)
			: base(apiKey)
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&artist={Artist}&album={Name}"; } }

		public string Name { get; set; } = string.Empty;

		public string Artist { get; set; } = string.Empty;

		private LfmAlbumMap AlbumMap { get; set; } = new LfmAlbumMap();

		public LfmAlbum GetInfo()
		{
			Method = "album.getinfo";

			ProcessRequest();
			return AlbumMap.Map(Response.SelectSingleNode("/lfm/album"));
		}
	}
}
