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
	public class LfmArtistContext : LfmContext
	{
		public LfmArtistContext(string name, LfmService service)
			: this(service)
		{
			Name = name;
		}

		public LfmArtistContext(LfmService service)
			: base(service)
		{ }

		public override string RequestUrl { get { return $"{RequestBase}&artist={WebUtility.UrlEncode(Name)}"; } }

		public string Name { get; set; } = string.Empty;

		private LfmArtistMap ArtistMap { get; set; } = new LfmArtistMap();

		private LfmTagMap TagMap { get; set; } = new LfmTagMap();

		private LfmTrackMap TrackMap { get; set; } = new LfmTrackMap();

		private LfmAlbumMap AlbumMap { get; set; } = new LfmAlbumMap();

		public void GetInfo(LfmArtist mapTo)
		{
			var artist = GetInfo();
			ArtistMap.Map(artist, mapTo);
		}

		public LfmArtist GetInfo()
		{
			Method = "artist.getinfo";

			ProcessRequest();
		
			var artist = ArtistMap.Map(Response.SelectSingleNode("/lfm/artist"));
			artist.Service = Service;
			artist.Service.ArtistContext.Name = artist.Name;

			return artist;
		}

		public IEnumerable<LfmTag> GetTopTags()
		{
			Method = "artist.getTopTags";

			ProcessRequest();
			return TagMap.Map(Response.SelectNodes("/lfm/toptags/tag"));
		}

		public IEnumerable<LfmArtist> GetSimilar()
		{
			Method = "artist.getSimilar";

			ProcessRequest();
			
			var artists = ArtistMap.Map(Response.SelectNodes("/lfm/similarartists/artist"));

			artists.ToList().ForEach(a =>
			{
				a.Service = Service;
				a.Service.ArtistContext.Name = a.Name;
			});

			return artists;
		}

		public IEnumerable<LfmTrack> GetTopTracks()
		{
			Method = "artist.getTopTracks";

			ProcessRequest();
			return TrackMap.Map(Response.SelectNodes("/lfm/toptracks/track"));
		}

		public IEnumerable<LfmAlbum> GetTopAlbums()
		{
			Method = "artist.getTopAlbums";

			ProcessRequest();
			var albums = AlbumMap.Map(Response.SelectNodes("/lfm/topalbums/album"));
			return albums;
		}
	}
}
