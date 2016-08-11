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
		public void Map(LfmUser from, LfmUser to)
		{
			to.Id = from.Id == 0 ? to.Id : from.Id;
			to.Name = string.IsNullOrEmpty(from.Name) ? to.Name : from.Name;
			to.RealName = string.IsNullOrEmpty(from.RealName) ? to.RealName : from.RealName;
			to.Images = from.Images.Count() == 0 ? to.Images : from.Images;
			to.Url = string.IsNullOrEmpty(from.Url) ? to.Url : from.Url;
			to.Country = string.IsNullOrEmpty(from.Country) ? to.Country : from.Country;
			to.Age = from.Age == 0 ? to.Age : from.Age;
			to.Gender = string.IsNullOrEmpty(from.Gender) ? to.Gender : from.Gender;
			to.Playcount = from.Playcount == 0 ? to.Playcount : from.Playcount;
			to.Playlists = from.Playlists == 0 ? to.Playlists : from.Playlists;
			to.Registered = from.Registered.Date == default(DateTime) ? to.Registered : from.Registered;
			to.Type = string.IsNullOrEmpty(from.Type) ? to.Type : from.Type;
		}

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
