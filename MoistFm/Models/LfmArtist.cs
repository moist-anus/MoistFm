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
			Service = service;
			Service.ArtistContext = new LfmArtistContext(Name, Service);
		}

		internal LfmArtist(string name)
			: this()
		{
			Name = name;
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

		public IEnumerable<LfmTag> TopTags { get; set; } = new List<LfmTag>();

		public IEnumerable<LfmTrack> TopTracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmAlbum> TopAlbums { get; set; } = new List<LfmAlbum>();

		public LfmBio Bio { get; set; } = new LfmBio();

		public LfmService Service { get; set; }

		public void GetInfo()
		{
			Service.ArtistContext.GetInfo(this);
		}

		public void GetTopTags()
		{
			TopTags = Service.ArtistContext.GetTopTags();
		}

		public void GetSimilar()
		{
			Similar = Service.ArtistContext.GetSimilar();
		}

		public void GetTopTracks()
		{
			TopTracks = Service.ArtistContext.GetTopTracks();
		}

		public void GetTopAlbums()
		{
			TopAlbums = Service.ArtistContext.GetTopAlbums();
		}
	}
}
