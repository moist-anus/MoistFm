using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Models
{
	public class Lfm
	{
		public LfmUser User { get; set; } = new LfmUser();

		public string Status { get; set; } = string.Empty;
	}
}
