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
		}

		public LfmService()
		{ }

		public string ApiKey { get; set; } = string.Empty;

		public LfmUserContext UserContext { get; internal set; } = new LfmUserContext();

		public LfmArtistContext ArtistContext { get; internal set; } = new LfmArtistContext();

		public LfmAlbumContext AlbumContext { get; internal set; } = new LfmAlbumContext();

		public LfmTrackContext TrackContext { get; internal set; } = new LfmTrackContext();
	}
}
