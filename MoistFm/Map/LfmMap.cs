using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoistFm.Map
{
	public abstract class LfmMap<T>
	{
		public IEnumerable<T> Map(XmlNodeList from)
		{
			foreach (XmlNode node in from)
			{
				yield return Map(node);
			}
		}

		public abstract T Map(XmlNode from);

		public static string GetText(XmlNode node)
		{
			return node == null ? string.Empty : node.InnerText;
		}

		public static bool IsNullOrEmpty(XmlNodeList nodes)
		{
			return nodes == null || nodes.Count == 0;
		}

		public static bool IsNullOrEmpty(XmlNode node)
		{
			return node == null || string.IsNullOrEmpty(node.InnerText);
		}
	}
}
