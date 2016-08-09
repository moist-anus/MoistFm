using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoistFm.Models;

namespace MoistFm.Map
{
	internal class LfmUserMap : LfmMap<LfmUser>
	{
		public override LfmUser Map(XmlNode from)
		{
			var idNode = from.SelectSingleNode("id");
			var nameNode = from.SelectSingleNode("name");
			var realnameNode = from.SelectSingleNode("realname");
			var imageNodes = from.SelectNodes("image");
			var urlNode = from.SelectSingleNode("url");
			var countryNode = from.SelectSingleNode("country");
			var ageNode = from.SelectSingleNode("age");
			var genderNode = from.SelectSingleNode("gender");
			var playcountNode = from.SelectSingleNode("playcount");
			var playlistsNode = from.SelectSingleNode("playlists");
			var registeredNode = from.SelectSingleNode("registered");
			var typeNode = from.SelectSingleNode("type");

			var user = new LfmUser();
			if (!IsNullOrEmpty(idNode)) user.Id = Convert.ToInt64(idNode.InnerText);
			if (!IsNullOrEmpty(playcountNode)) user.Playcount = Convert.ToInt32(playcountNode.InnerText);
			if (!IsNullOrEmpty(playlistsNode)) user.Playlists = Convert.ToInt32(playlistsNode.InnerText);
			if (!IsNullOrEmpty(ageNode)) user.Age = Convert.ToInt16(ageNode.InnerText);
			user.Images = new LfmImageMap().Map(imageNodes);
			user.Registered = new LfmRegisteredMap().Map(registeredNode);
			user.Name = GetText(nameNode);
			user.RealName = GetText(realnameNode);
			user.Url = GetText(urlNode);
			user.Country = GetText(countryNode);
			user.Gender = GetText(genderNode);
			user.Type = GetText(typeNode);

			return user;
		}
	}
}
