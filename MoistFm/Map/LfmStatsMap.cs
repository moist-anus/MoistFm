using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmStatsMap : LfmMap<LfmStats>
	{
		public LfmStats Map(int listeners, int playcount)
		{
			return new LfmStats(listeners, playcount);
		}

		public override LfmStats Map(XmlNode from)
		{
			var listenersNode = from.SelectSingleNode("listeners");
			var playcountNode = from.SelectSingleNode("playcount");

			var stats = new LfmStats();
			if (!IsNullOrEmpty(listenersNode)) stats.Listeners = Convert.ToInt32(listenersNode.InnerText);
			if (!IsNullOrEmpty(playcountNode)) stats.Playcount = Convert.ToInt32(playcountNode.InnerText);

			return stats;
		}
	}
}
