using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmAlbumMap : LfmMap<LfmAlbum>
	{
		public void Map(LfmAlbum from, LfmAlbum to)
		{
			to.Name = string.IsNullOrEmpty(from.Name) ? to.Name : from.Name;
			to.MbId = from.MbId == default(Guid) ? to.MbId : from.MbId;
			to.Url = string.IsNullOrEmpty(from.Url) ? to.Url : from.Url;
			to.Artist = string.IsNullOrEmpty(from.Artist.Name) ? to.Artist : from.Artist;
			to.Images = from.Images.Count() == 0 ? to.Images : from.Images;
			to.Stats = from.Stats.Playcount == 0 || from.Stats.Listeners == 0 ? to.Stats : from.Stats;
			to.Tracks = from.Tracks.Count() == 0 ? to.Tracks : from.Tracks;
			to.Tags = from.Tags.Count() == 0 ? to.Tags : from.Tags;
			to.Wiki = string.IsNullOrEmpty(from.Wiki.Summary) ? to.Wiki : from.Wiki;
		}

		public override LfmAlbum Map(XmlNode from)
		{
			var nameNode = from.SelectSingleNode("name");
			var titleNode = from.SelectSingleNode("title");
			var playcountNode = from.SelectSingleNode("playcount");
			var urlNode = from.SelectSingleNode("url");
			var artistNode = from.SelectSingleNode("artist");
			var imageNodes = from.SelectNodes("image");
			var listenersNode = from.SelectSingleNode("listeners");
			var trackNodes = from.SelectNodes("tracks/track");
			var tagNodes = from.SelectNodes("tags/tag");
			var wikiNode = from.SelectSingleNode("wiki");

			var album = new LfmAlbum();

			album.Name = IsNullOrEmpty(nameNode) ? IsNullOrEmpty(titleNode) ? from.InnerText : GetText(titleNode) : GetText(nameNode);
			if (!IsNullOrEmpty(urlNode)) album.Url = urlNode.InnerText;
			if (!IsNullOrEmpty(imageNodes)) album.Images = new LfmImageMap().Map(imageNodes);
			if (!IsNullOrEmpty(trackNodes)) album.Tracks = new LfmTrackMap().Map(trackNodes);
			if (!IsNullOrEmpty(tagNodes)) album.Tags = new LfmTagMap().Map(tagNodes);
			if (!IsNullOrEmpty(wikiNode)) album.Wiki = new LfmBioMap().Map(wikiNode);

			var artistMap = new LfmArtistMap();

			if (!IsNullOrEmpty(artistNode) && artistNode.ChildNodes.Count == 1)
			{
				album.Artist = artistMap.Map(artistNode.InnerText);
			}
			else if (!IsNullOrEmpty(artistNode))
			{
				album.Artist = artistMap.Map(artistNode);
			}
	
			if (!IsNullOrEmpty(playcountNode) && !IsNullOrEmpty(listenersNode))
			{
				album.Stats = new LfmStatsMap().Map(Convert.ToInt32(listenersNode.InnerText), Convert.ToInt32(playcountNode.InnerText));
			}

			return album;
		}
	}
}
