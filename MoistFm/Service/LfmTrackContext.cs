using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public class LfmTrackContext : LfmContext
	{
		public LfmTrackContext(string name, string artist, string apiKey)
			: this(apiKey)
		{
			Name = name;
			Artist = artist;
		}

		public LfmTrackContext(string apiKey)
			: base(apiKey)
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&track={Name}&artist={Artist}"; } }

		public string Name { get; set; } = string.Empty;

		public string Artist { get; set; } = string.Empty;

		private LfmTrackMap TrackMap { get; set; } = new LfmTrackMap();

		public LfmTrack GetInfo()
		{
			Method = "track.getInfo";

			ProcessRequest();
			return TrackMap.Map(Response.SelectSingleNode("/lfm/track"));
		}
	}
}
