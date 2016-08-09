using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Service;

namespace MoistFm.Models
{
	public class LfmArtist
	{
		public LfmArtist(string name, LfmService service)
			: this()
		{
			Name = name;
			service.ArtistContext = new LfmArtistContext(Name);
			Context = service.ArtistContext;
		}

		internal LfmArtist(string name)
			: this()
		{
			Name = name;
			Context = new LfmArtistContext(Name);
		}

		public LfmArtist()
		{ }

		public string Name { get; set; } = string.Empty;

		public int Playcount { get; set; } = 0;

		public Guid MbId { get; set; } = default(Guid);

		public string Url { get; set; } = string.Empty;

		public IEnumerable<LfmImage> Images { get; set; } = new List<LfmImage>();

		public bool Streamable { get; set; } = false;

		public bool OnTour { get; set; } = false;

		public LfmStats Stats { get; set; } = new LfmStats();

		public IEnumerable<LfmArtist> Similar { get; set; } = new List<LfmArtist>();

		public IEnumerable<LfmTag> Tags { get; set; } = new List<LfmTag>();

		public LfmBio Bio { get; set; } = new LfmBio();

		private LfmArtistContext Context { get; set; }

		public LfmArtist GetInfo()
		{
			return Context.GetInfo();
		}

		public IEnumerable<LfmTag> GetTopTags()
		{
			return Context.GetTopTags();
		}

		public IEnumerable<LfmArtist> GetSimilar()
		{
			return Context.GetSimilar();
		}

		public IEnumerable<LfmTrack> GetTopTracks()
		{
			return Context.GetTopTracks();
		}

		public IEnumerable<LfmAlbum> GetTopAlbums()
		{
			return Context.GetTopAlbums();
		}
	}
}
