﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public class LfmTrackContext : LfmContext
	{
		public LfmTrackContext(string name, string artist, LfmService service)
			: this(service)
		{
			Name = name;
			Artist = artist;
		}

		public LfmTrackContext(LfmService service)
			: base(service)
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&track={WebUtility.UrlEncode(Name)}&artist={WebUtility.UrlEncode(Artist)}"; } }

		public string Name { get; set; } = string.Empty;

		public string Artist { get; set; } = string.Empty;

		private LfmTrackMap TrackMap { get; set; } = new LfmTrackMap();

		public void GetInfo(LfmTrack mapTo)
		{
			if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Artist))
			{
				return;
			}

			var track = GetInfo();
			TrackMap.Map(track, mapTo);
		}

		public LfmTrack GetInfo()
		{
			Method = "track.getInfo";
			ProcessRequest();
			var track =  TrackMap.Map(Response.SelectSingleNode("/lfm/track"));
			track.Service = Service;
			track.Service.TrackContext.Name = track.Name;
			track.Service.TrackContext.Artist = track.Artist.Name;

			return track;
		}
	}
}
