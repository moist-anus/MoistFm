using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;
using MoistFm.Service;

namespace MoistFm.Map
{
	public class LfmRegisteredMap : LfmMap<LfmRegistered>
	{
		public override LfmRegistered Map(XmlNode from)
		{
			return new LfmRegistered()
			{
				UnixTime = Convert.ToInt64(from.Attributes["unixtime"].Value),
				Date = LfmUtil.ConvertUnixTimestamp(Convert.ToInt64(from.Attributes["unixtime"].Value))
			};
		}
	}
}
