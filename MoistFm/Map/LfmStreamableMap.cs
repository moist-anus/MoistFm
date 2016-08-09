using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	public class LfmStreamableMap : LfmMap<LfmStreamable>
	{
		public override LfmStreamable Map(XmlNode from)
		{
			var fulltrackAttribute = from.Attributes["fulltrack"];

			var streamable = new LfmStreamable();
			if (!IsNullOrEmpty(fulltrackAttribute)) streamable.IsFullTrack = !string.Equals(fulltrackAttribute.Value, "0", StringComparison.OrdinalIgnoreCase);
			streamable.IsStreamable = !string.Equals(from.InnerText, "0", StringComparison.OrdinalIgnoreCase);

			return streamable;
		}
	}
}
