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
			service.UserContext = new LfmUserContext(Name);
			Context = service.UserContext;
		}

		internal LfmUser(string name)
			: this()
		{
			Name = name;
			Context = new LfmUserContext(Name);
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

		private LfmUserContext Context { get; set; }

		public LfmUser GetInfo()
		{
			return Context.GetInfo();
		}

		public IEnumerable<LfmUser> GetFriends()
		{
			return Context.GetFriends();
		}

		public IEnumerable<LfmArtist> GetTopArtists()
		{
			return Context.GetTopArtists();
		}

		public IEnumerable<LfmTag> GetTopTags()
		{
			return Context.GetTopTags();
		}

		public IEnumerable<LfmTrack> GetLovedTracks()
		{
			return Context.GetLovedTracks();
		}

		public IEnumerable<LfmTrack> GetArtistTracks(string artist)
		{
			return Context.GetArtistTracks(artist);
		}

		public IEnumerable<LfmTrack> GetRecentTracks()
		{
			return Context.GetRecentTracks();
		}

		public IEnumerable<LfmAlbum> GetTopAlbums()
		{
			return Context.GetTopAlbums();
		}

		public IEnumerable<LfmTrack> GetTopTracks()
		{
			return Context.GetTopTracks();
		}

		public IEnumerable<LfmAlbum> GetWeeklyAlbumChart()
		{
			return Context.GetWeeklyAlbumChart();
		}

		public IEnumerable<LfmArtist> GetWeeklyArtistChart()
		{
			return Context.GetWeeklyArtistChart();
		}

		public IEnumerable<LfmTrack> GetWeeklyTrackChart()
		{
			return Context.GetWeeklyTrackChart();
		}

		public LfmTrack GetNowPlaying()
		{
			return Context.GetNowPlaying();
		}
	}
}
