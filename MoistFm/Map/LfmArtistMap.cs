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
			if (!IsNullOrEmpty(tagNodes)) artist.Tags = new LfmTagMap().Map(tagNodes);
			if (!IsNullOrEmpty(bioNode)) artist.Bio = new LfmBioMap().Map(bioNode);
			artist.Name = !IsNullOrEmpty(nameNode) ? nameNode.InnerText : from.InnerText;
			artist.Url = GetText(urlNode);

			return artist;
		}
	}
}
