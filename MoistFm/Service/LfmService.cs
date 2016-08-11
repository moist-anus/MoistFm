using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Service;

namespace MoistFm
{
	public class LfmService
	{
		public LfmService(string apiKey)
			: this()
		{
			ApiKey = apiKey;
			UserContext = new LfmUserContext(this);
			ArtistContext = new LfmArtistContext(this);
			AlbumContext = new LfmAlbumContext(this);
			TrackContext = new LfmTrackContext(this);
		}

		public LfmService()
		{ }

		public string ApiKey { get; set; } = string.Empty;

		public LfmUserContext UserContext { get; internal set; }

		public LfmArtistContext ArtistContext { get; internal set; }

		public LfmAlbumContext AlbumContext { get; internal set; }

		public LfmTrackContext TrackContext { get; internal set; }
	}
}
