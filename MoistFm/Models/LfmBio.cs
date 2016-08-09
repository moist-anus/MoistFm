using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Models
{
	public class LfmBio
	{
		public IEnumerable<LfmLink> Links { get; set; } = new List<LfmLink>();

		public DateTime Published { get; set; } = default(DateTime);

		public string Summary { get; set; } = string.Empty;

		public string Content { get; set; } = string.Empty;
	}
}
