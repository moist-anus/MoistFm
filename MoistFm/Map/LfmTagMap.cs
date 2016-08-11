using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmTagMap : LfmMap<LfmTag>
	{
		public void Map(LfmTag from, LfmTag to)
		{
			to.Name = string.IsNullOrEmpty(from.Name) ? to.Name : from.Name;
			to.Url = string.IsNullOrEmpty(from.Url) ? to.Url : from.Url;
			to.Count = from.Count == 0 ? to.Count : from.Count;
		}

		public override LfmTag Map(XmlNode from)
		{
			var nameNode = from.SelectSingleNode("name");
			var urlNode = from.SelectSingleNode("url");
			var countNode = from.SelectSingleNode("count");

			var tag = new LfmTag();
			tag.Name = GetText(nameNode);
			tag.Url = GetText(urlNode);
			if (!IsNullOrEmpty(countNode)) tag.Count = Convert.ToInt32(countNode.InnerText);

			return tag;
		}
	}
}
