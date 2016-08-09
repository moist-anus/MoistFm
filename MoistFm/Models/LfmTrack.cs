using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Service;

namespace MoistFm.Models
{
	public class LfmTrack
	{
		public LfmTrack(string name, string artist, LfmService service)
			: this()
		{
			Name = name;
			Artist = new LfmArtist(artist);
			service.TrackContext = new LfmTrackContext(Name, Artist.Name);
			Context = service.TrackContext;
		}

		internal LfmTrack(string name, string artist)
			: this()
		{
			Name = name;
			Artist = new LfmArtist(artist);
			Context = new LfmTrackContext(Name, Artist.Name);
		}

		public LfmTrack()
		{	}

		public string Name { get; set; } = string.Empty;

		public Guid MbId { get; set; } = default(Guid);

		public string Url { get; set; } = string.Empty;

		public int Duration { get; set; } = 0;

		public LfmStreamable Streamable { get; set; } = new LfmStreamable();

		public LfmStats Stats { get; set; } = new LfmStats();

		public LfmArtist Artist { get; set; } = new LfmArtist();

		public LfmAlbum Album { get; set; } = new LfmAlbum();

		public IEnumerable<LfmTag> Tags { get; set; } = new List<LfmTag>();

		public LfmBio Wiki { get; set; } = new LfmBio();

		public DateTime Date { get; set; } = default(DateTime);

		public IEnumerable<LfmImage> Images { get; set; } = new List<LfmImage>();

		public bool NowPlaying { get; set; } = false;

		private LfmTrackContext Context { get; set; }

		public LfmTrack GetInfo()
		{
			return Context.GetInfo();
		}
	}
}
