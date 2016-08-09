using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Models
{
	public class LfmStats
	{
		public LfmStats(int listeners, int playcount)
			: this()
		{
			Listeners = listeners;
			Playcount = playcount;
		}

		public LfmStats()
		{ }

		public int Listeners { get; set; } = 0;

		public int Playcount { get; set; } = 0;
	}
}
