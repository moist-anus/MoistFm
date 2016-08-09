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

		public override LfmTrack Map(XmlNode from)
		{
			var nameNode = from.SelectSingleNode("name");
			var mbIdNode = from.SelectSingleNode("mbid");
			var urlNode = from.SelectSingleNode("url");
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

			if (!IsNullOrEmpty(playcountNode) && !IsNullOrEmpty(listenersNode))
			{
				track.Stats = new LfmStatsMap().Map(Convert.ToInt32(listenersNode.InnerText), Convert.ToInt32(playcountNode.InnerText));
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

			return track;
		}
	}
}
