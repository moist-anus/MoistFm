using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmArtistMap : LfmMap<LfmArtist>
	{
		public LfmArtist Map(string name)
		{
			return new LfmArtist(name);
		}

		public void Map(LfmArtist from, LfmArtist to)
		{
			to.Name = string.IsNullOrEmpty(from.Name) ? to.Name : from.Name;
			to.Playcount = from.Playcount == 0 ? to.Playcount : from.Playcount;
			to.MbId = from.MbId == default(Guid) ? to.MbId : from.MbId;
			to.Url = string.IsNullOrEmpty(from.Url) ? to.Url : from.Url;
			to.Images = from.Images.Count() == 0 ? to.Images : from.Images;
			to.Streamable = from.Streamable;
			to.OnTour = from.OnTour;
			to.Stats = from.Stats.Listeners == 0 || from.Stats.Playcount == 0 ? to.Stats : from.Stats;
			to.Similar = from.Similar.Count() == 0 ? to.Similar : from.Similar;
			to.TopTags = from.TopTags.Count() == 0 ? to.TopTags : from.TopTags;
			to.Bio = string.IsNullOrEmpty(from.Bio.Summary) ? to.Bio : from.Bio;
		}

		public override LfmArtist Map(XmlNode from)
		{
			var nameNode = from.SelectSingleNode("name");
			var playcountNode = from.SelectSingleNode("playcount");
			var mbIdNode = from.SelectSingleNode("mbid");
			var urlNode = from.SelectSingleNode("url");
			var imageNodes = from.SelectNodes("image");
			var streamableNode = from.SelectSingleNode("streamable");
			var onTourNode = from.SelectSingleNode("ontour");
			var statsNode = from.SelectSingleNode("stats");
			var similarNodes = from.SelectNodes("similar/artist");
			var tagNodes = from.SelectNodes("tags/tag");
			var bioNode = from.SelectSingleNode("bio");

			var artist = new LfmArtist();
			
			if (!IsNullOrEmpty(playcountNode)) artist.Playcount = Convert.ToInt32(playcountNode.InnerText);
			if (!IsNullOrEmpty(mbIdNode)) artist.MbId = new Guid(mbIdNode.InnerText);
			if (!IsNullOrEmpty(imageNodes)) artist.Images = new LfmImageMap().Map(imageNodes);
			if (!IsNullOrEmpty(streamableNode)) artist.Streamable = string.Equals(streamableNode.InnerText, "1", StringComparison.OrdinalIgnoreCase);
			if (!IsNullOrEmpty(onTourNode)) artist.OnTour = string.Equals(onTourNode.InnerText, "1", StringComparison.OrdinalIgnoreCase);
			if (!IsNullOrEmpty(statsNode)) artist.Stats = new LfmStatsMap().Map(statsNode);
			if (!IsNullOrEmpty(similarNodes)) artist.Similar = Map(similarNodes);
			if (!IsNullOrEmpty(tagNodes)) artist.TopTags = new LfmTagMap().Map(tagNodes);
			if (!IsNullOrEmpty(bioNode)) artist.Bio = new LfmBioMap().Map(bioNode);
			artist.Name = !IsNullOrEmpty(nameNode) ? nameNode.InnerText : from.InnerText;
			artist.Url = GetText(urlNode);

			return artist;
		}
	}
}
