using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Service;

namespace MoistFm.Models
{
	public class LfmAlbum
	{
		public LfmAlbum(string name, string artist, LfmService service)
			: this()
		{
			Name = name;
			Artist = new LfmArtist(artist, service);
			service.AlbumContext = new LfmAlbumContext(Name, Artist.Name);
			Context = service.AlbumContext;
		}

		internal LfmAlbum(string name, string artist)
			: this()
		{
			Name = name;
			Artist = new LfmArtist(artist);
			Context = new LfmAlbumContext(Name, Artist.Name);
		}

		public LfmAlbum()
		{ }

		public string Name { get; set; } = string.Empty;

		public Guid MbId { get; set; } = default(Guid);

		public string Url { get; set; } = string.Empty;

		public LfmArtist Artist { get; set; } = new LfmArtist();

		public IEnumerable<LfmImage> Images { get; set; } = new List<LfmImage>();

		public LfmStats Stats { get; set; } = new LfmStats();

		public IEnumerable<LfmTrack> Tracks { get; set; } = new List<LfmTrack>();

		public IEnumerable<LfmTag> Tags { get; set; } = new List<LfmTag>();

		public LfmBio Wiki { get; set; } = new LfmBio();

		private LfmAlbumContext Context { get; set; }

		public LfmAlbum GetInfo()
		{
			return Context.GetInfo();
		}
	}
}
