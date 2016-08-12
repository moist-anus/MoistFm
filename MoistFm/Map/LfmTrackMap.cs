using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmTrackMap : LfmMap<LfmTrack>
	{
		public LfmTrackMap()
		{ }

		public void Map(LfmTrack from, LfmTrack to)
		{
			to.Name = string.IsNullOrEmpty(from.Name) ? to.Name : from.Name;
			to.MbId = from.MbId == default(Guid) ? to.MbId : from.MbId;
			to.Url = string.IsNullOrEmpty(from.Url) ? to.Url : from.Url;
			to.Duration = from.Duration == 0 ? to.Duration : from.Duration;
			to.Stats = from.Stats.Listeners == 0 || from.Stats.Playcount == 0 ? to.Stats : from.Stats;
			to.Album = string.IsNullOrEmpty(from.Album.Name) ? to.Album : from.Album;
			to.Tags = from.Tags.Count() == 0 ? to.Tags : from.Tags;
			to.Wiki = string.IsNullOrEmpty(from.Wiki.Summary) ? to.Wiki : from.Wiki;
			to.Date = from.Date == default(DateTime) ? to.Date : from.Date;
			to.Images = from.Images.Count() == 0 ? to.Images : from.Images;
		}

		public override LfmTrack Map(XmlNode from)
		{
			var nameNode = from.SelectSingleNode("name");
			var mbIdNode = from.SelectSingleNode("mbid");
			var urlNode = from.SelectSingleNode("url");
			var durationNode = from.SelectSingleNode("duration");
			var dateNode = from.SelectSingleNode("date");
			var imageNodes = from.SelectNodes("image");
			var streamableNode = from.SelectSingleNode("streamable");
			var nowPlayingAttribute = from.Attributes["nowplaying"];
			var playcountNode = from.SelectSingleNode("playcount");
			var listenersNode = from.SelectSingleNode("listeners");
			var artistNode = from.SelectSingleNode("artist");
			var albumNode = from.SelectSingleNode("album");
			var tagNodes = from.SelectNodes("toptags/tag");
			var wikiNode = from.SelectSingleNode("wiki");

			var track = new LfmTrack();

			if (!IsNullOrEmpty(playcountNode) || !IsNullOrEmpty(listenersNode))
			{
				var listeners = IsNullOrEmpty(listenersNode) ? 0 : Convert.ToInt32(listenersNode.InnerText);
				var playcount = IsNullOrEmpty(playcountNode) ? 0 : Convert.ToInt32(playcountNode.InnerText);
				track.Stats = new LfmStatsMap().Map(listeners, playcount);
			}

			track.Name = GetText(nameNode);
			if (!IsNullOrEmpty(artistNode)) track.Artist = new LfmArtistMap().Map(artistNode);
			if (!IsNullOrEmpty(albumNode)) track.Album = new LfmAlbumMap().Map(albumNode);
			if (!IsNullOrEmpty(tagNodes)) track.Tags = new LfmTagMap().Map(tagNodes);
			if (!IsNullOrEmpty(wikiNode)) track.Wiki = new LfmBioMap().Map(wikiNode);
			if (!IsNullOrEmpty(mbIdNode)) track.MbId = new Guid(mbIdNode.InnerText);
			if (dateNode != null) track.Date = Convert.ToDateTime(dateNode.InnerText);
			if (!IsNullOrEmpty(imageNodes)) track.Images = new LfmImageMap().Map(imageNodes);
			if (!IsNullOrEmpty(streamableNode)) track.Streamable = new LfmStreamableMap().Map(from.SelectSingleNode("streamable"));
			if (!IsNullOrEmpty(nowPlayingAttribute)) track.NowPlaying = Convert.ToBoolean(nowPlayingAttribute.Value);
			track.Url = GetText(urlNode);
			if (!IsNullOrEmpty(durationNode)) track.Duration = Convert.ToInt32(durationNode.InnerText);

			return track;
		}
	}
}
