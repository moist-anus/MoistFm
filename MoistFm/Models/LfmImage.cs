using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Models
{
	public class LfmImage
	{
		public LfmImage(string size, string url)
		{
			Size = size;
			Url = url;
		}

		public LfmImage()
		{ }

		public string Size { get; set; } = string.Empty;

		public string Url { get; set; } = string.Empty;
	}
}
