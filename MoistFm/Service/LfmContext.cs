using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using MoistFm.Map;
using MoistFm.Models;

namespace MoistFm.Service
{
	public abstract class LfmContext
	{
		public LfmContext()
		{ }

		public abstract string RequestUrl { get; }

		public static string ApiKey { get; set; } = "14e266cd3ede4e2eeb1a9fbd018b7eac";

		public static string UrlBase { get; set; } = "http://ws.audioscrobbler.com/2.0/";

		public XmlDocument Response { get; protected set; } = new XmlDocument();

		public string Method { get; set; } = string.Empty;

		protected string RequestBase
		{
			get { return $"{UrlBase}?method={Method}&api_key={ApiKey}"; }
		}

		protected void ProcessRequest(string url)
		{
			try
			{
				var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
				var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

				Response.Load(httpWebResponse.GetResponseStream());
			}
			catch (Exception ex)
			{
				Response.InnerText = ex.Message;
			}
		}

		protected void ProcessRequest()
		{
			ProcessRequest(RequestUrl);
		}
	}
}
