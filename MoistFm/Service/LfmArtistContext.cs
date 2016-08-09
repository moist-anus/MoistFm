using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public class LfmArtistContext : LfmContext
	{
		public LfmArtistContext(string name)
			: this()
		{
			Name = name;
		}

		public LfmArtistContext()
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&artist={Name}"; } }

		public string Name { get; set; } = string.Empty;

		private LfmArtistMap ArtistMap { get; set; } = new LfmArtistMap();

		private LfmTagMap TagMap { get; set; } = new LfmTagMap();

		private LfmTrackMap TrackMap { get; set; } = new LfmTrackMap();

		private LfmAlbumMap AlbumMap { get; set; } = new LfmAlbumMap();

		public LfmArtist GetInfo()
		{
			Method = "artist.getinfo";

			ProcessRequest();
			return ArtistMap.Map(Response.SelectSingleNode("/lfm/artist"));
		}

		public IEnumerable<LfmTag> GetTopTags()
		{
			Method = "artist.getTopTags";

			ProcessRequest();
			return TagMap.Map(Response.SelectNodes("/lfm/toptags/tag"));
		}

		public IEnumerable<LfmArtist> GetSimilar()
		{
			Method = "artist.getSimilar";

			ProcessRequest();
			return ArtistMap.Map(Response.SelectNodes("/lfm/similarartists/artist"));
		}

		public IEnumerable<LfmTrack> GetTopTracks()
		{
			Method = "artist.getTopTracks";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/toptracks/track"));
		}

		public IEnumerable<LfmAlbum> GetTopAlbums()
		{
			Method = "artist.getTopAlbums";

			ProcessRequest();
			return AlbumMap.Map(Response.SelectNodes("/lfm/topalbums/album"));
		}
	}
}
