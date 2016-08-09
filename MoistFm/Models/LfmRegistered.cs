using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Models
{
	public class LfmRegistered
	{
		public LfmRegistered(int unixTime, DateTime date)
			: this()
		{
			UnixTime = unixTime;
			Date = date;
		}

		public LfmRegistered()
		{ }

		public long UnixTime { get; set; } = 0;

		public DateTime Date { get; set; } = default(DateTime);
	}
}
