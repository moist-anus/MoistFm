using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmBioMap : LfmMap<LfmBio>
	{
		public override LfmBio Map(XmlNode from)
		{
			var linkNodes = from.SelectNodes("links");
			var publishedNode = from.SelectSingleNode("published");
			var summaryNode = from.SelectSingleNode("summary");
			var contentNode = from.SelectSingleNode("content");

			var bio = new LfmBio();
			if (!IsNullOrEmpty(linkNodes)) bio.Links = new LfmLinkMap().Map(linkNodes);
			if (!IsNullOrEmpty(publishedNode)) bio.Published = Convert.ToDateTime(publishedNode.InnerText);
			bio.Summary = GetText(summaryNode);
			bio.Content = GetText(contentNode);

			return bio;
		}
	}
}
