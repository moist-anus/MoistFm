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
	public class LfmUserContext : LfmContext
	{
		public LfmUserContext(string name, string apiKey)
			: this(apiKey)
		{
			Name = name;
		}

		public LfmUserContext(string apiKey)
			: base(apiKey)
		{ }

		public override string RequestUrl
		{
			get
			{
				return $"{RequestBase}&user={Name}";
			}
		}

		public string Name { get; set; } = string.Empty;

		private LfmUserMap UserMap { get; set; } = new LfmUserMap();

		private LfmArtistMap ArtistMap { get; set; } = new LfmArtistMap();

		private LfmTagMap TagMap { get; set; } = new LfmTagMap();

		private LfmTrackMap TrackMap { get; set; } = new LfmTrackMap();

		private LfmAlbumMap AlbumMap { get; set; } = new LfmAlbumMap();

		public IEnumerable<LfmTrack> GetArtistTracks(string artist)
		{
			Method = "user.getartisttracks";

			ProcessRequest($"{RequestUrl}&artist={artist}");
			return TrackMap.Map(Response.SelectNodes("/lfm/artisttracks/track"));
		}

		public IEnumerable<LfmUser> GetFriends()
		{
			Method = "user.getfriends";

			ProcessRequest();
			return UserMap.Map(Response.SelectNodes("/lfm/friends/user"));
		}

		public LfmUser GetInfo()
		{
			Method = "user.getinfo";

			ProcessRequest();
			return UserMap.Map(Response.SelectSingleNode("/lfm/user"));
		}

		public IEnumerable<LfmTrack> GetLovedTracks()
		{
			Method = "user.getlovedtracks";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/lovedtracks/track"));
		}

		public IEnumerable<LfmTrack> GetRecentTracks()
		{
			Method = "user.getrecenttracks";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/recenttracks/track"));
		}

		public IEnumerable<LfmAlbum> GetTopAlbums()
		{
			Method = "user.gettopalbums";

			ProcessRequest();
			return AlbumMap.Map(Response.SelectNodes("/lfm/topalbums/album"));
		}

		public IEnumerable<LfmArtist> GetTopArtists()
		{
			Method = "user.gettopartists";
			
			ProcessRequest();
			return ArtistMap.Map(Response.SelectNodes("/lfm/topartists/artist"));
		}

		public IEnumerable<LfmTag> GetTopTags()
		{
			Method = "user.gettoptags";

			ProcessRequest();
			return TagMap.Map(Response.SelectNodes("/lfm/toptags/tag"));
		}

		public IEnumerable<LfmTrack> GetTopTracks()
		{
			Method = "user.gettoptracks";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/toptracks/track"));
		}	

		public IEnumerable<LfmAlbum> GetWeeklyAlbumChart()
		{
			Method = "user.getweeklyalbumchart";

			ProcessRequest();
			return AlbumMap.Map(Response.SelectNodes("/lfm/weeklyalbumchart/album"));
		}

		public IEnumerable<LfmArtist> GetWeeklyArtistChart()
		{
			Method = "user.getweeklyartistchart";

			ProcessRequest();
			return ArtistMap.Map(Response.SelectNodes("/lfm/weeklyartistchart/artist"));
		}

		public IEnumerable<LfmTrack> GetWeeklyTrackChart()
		{
			Method = "user.getweeklytrackchart";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/weeklytrackchart/track"));
		}

		public LfmTrack GetNowPlaying()
		{
			Method = "user.getrecenttracks";
			ProcessRequest($"{RequestUrl}&limit=1");

			var nowPlayingNode = Response.SelectSingleNode("/lfm/recenttracks/track[@nowplaying='true']");

			return nowPlayingNode == null ? new LfmTrack() : TrackMap.Map(nowPlayingNode);
		}
	}
}
