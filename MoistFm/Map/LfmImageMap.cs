using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmImageMap : LfmMap<LfmImage>
	{
		public override LfmImage Map(XmlNode from)
		{
			return new LfmImage()
			{
				Size = from.Attributes["size"].Value,
				Url = from.InnerText
			};
		}
	}
}
