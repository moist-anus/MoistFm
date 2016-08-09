using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmLinkMap : LfmMap<LfmLink>
	{
		public override LfmLink Map(XmlNode from)
		{
			return new LfmLink()
			{
				Rel = from.Attributes["rel"].Value,
				Href = from.Attributes["href"].Value
			};
		}
	}
}
