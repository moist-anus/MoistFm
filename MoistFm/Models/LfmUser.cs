using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Service;

namespace MoistFm.Models
{
	public class LfmUser
	{
		public LfmUser(string name, LfmService service)
			: this()
		{
			Name = name;
			Service = service;
			service.UserContext = new LfmUserContext(Name, Service);
		}

		public LfmUser()
		{ }

		public long Id { get; set; } = 0;

		public string Name { get; set; } = string.Empty;

		public string RealName { get; set; } = string.Empty;

		public IEnumerable<LfmImage> Images { get; set; } = new List<LfmImage>();

		public string Url { get; set; } = string.Empty;

		public string Country { get; set; } = string.Empty;

		public int Age { get; set; } = 0;

		public string Gender { get; set; } = string.Empty;

		public byte Subscriber { get; set; }

		public int Playcount { get; set; } = 0;

		public int Playlists { get; set; } = 0;

		public byte Bootstrap { get; set; }

		public LfmRegistered Registered { get; set; } = new LfmRegistered();

		public string Type { get; set; } = string.Empty;

		public IEnumerable<LfmUser> Friends { get; set; } = new List<LfmUser>();

		public IEnumerable<LfmArtist> TopArtists { get; set; } = new List<LfmArtist>();

		public IEnumerable<LfmTag> TopTags { get; set; } = new List<LfmTag>();

		public IEnumerable<LfmTrack> LovedTracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmTrack> ArtistTracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmAlbum> TopAlbums { get; set; } = new List<LfmAlbum>();

		public IEnumerable<LfmTrack> RecentTracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmTrack> TopTracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmAlbum> WeeklyAlbumChart { get; set; } = new List<LfmAlbum>();

		public IEnumerable<LfmArtist> WeeklyArtistChart { get; set; } = new List<LfmArtist>();

		public IEnumerable<LfmTrack> WeeklyTrackChart { get; set; } = new List<LfmTrack>();

		public LfmTrack NowPlaying { get; set; } = new LfmTrack();

		public LfmService Service { get; set; }

		public void GetInfo()
		{
			Service.UserContext.GetInfo(this);
		}

		public void GetFriends()
		{
			Friends = Service.UserContext.GetFriends();
		}

		public void GetTopArtists()
		{
			TopArtists = Service.UserContext.GetTopArtists();
		}

		public void GetTopTags()
		{
			TopTags = Service.UserContext.GetTopTags();
		}

		public void GetLovedTracks()
		{
			LovedTracks = Service.UserContext.GetLovedTracks();
		}

		public void GetArtistTracks(string artist)
		{
			ArtistTracks = Service.UserContext.GetArtistTracks(artist);
		}

		public void GetRecentTracks()
		{
			RecentTracks = Service.UserContext.GetRecentTracks();
		}

		public void GetTopAlbums()
		{
			TopAlbums = Service.UserContext.GetTopAlbums();
		}

		public void GetTopTracks()
		{
			TopTracks =  Service.UserContext.GetTopTracks();
		}

		public void GetWeeklyAlbumChart()
		{
			WeeklyAlbumChart = Service.UserContext.GetWeeklyAlbumChart();
		}

		public void GetWeeklyArtistChart()
		{
			WeeklyArtistChart = Service.UserContext.GetWeeklyArtistChart();
		}

		public void GetWeeklyTrackChart()
		{
			WeeklyTrackChart = Service.UserContext.GetWeeklyTrackChart();
		}

		public void GetNowPlaying()
		{
			NowPlaying = Service.UserContext.GetNowPlaying();
		}
	}
}
