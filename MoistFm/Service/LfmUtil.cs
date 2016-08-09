using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Service
{
	public class LfmUtil
	{
		public static DateTime ConvertUnixTimestamp(long seconds)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(seconds);
		}
	}
}
