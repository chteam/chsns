using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CHSNS {
	public class CHPath {
		public string GetFace_Small(long userid) {
			return GetFace(userid, ImgSize.Small);
		}
		public string GetFace_Middle(long userid) {
			return GetFace(userid, ImgSize.Middle);
		}
		public string GetFace_Big() {
			return GetFace_Big(CHUser.UserID);
		}
		public string GetFace_Big(long userid) {
			return GetFace(userid, ImgSize.Big);
		}
		/// <summary>
		/// 用户头像
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		public string GetFace(long userid, ImgSize size) {
			if (userid.ToString().Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", ClientUserFolder(userid), userid.ToString().Substring(0, 3), size.ToString());
				if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			}
			return EmptyUserFace(size);
		}
		string EmptyUserFace(ImgSize size) {
			return string.Format("/images/no_{0}.jpg", size.ToString());
			//return "/images/no.gif";
		}
		/// <summary>
		/// 用户的文件夹
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		public string ClientUserFolder(long userid) {
			return string.Format(
				"/userFiles/{0}/{1}/{2}/{3}/",
				new object[] { 
					userid.ToString().Substring(userid.ToString().Length - 2, 1),
					userid.ToString().Substring(userid.ToString().Length - 1, 1), 
					userid.ToString().Substring(userid.ToString().Length - 3, 1), userid.ToString()
				}
				);
		}
		/// <summary>
		/// 得到用户的文件夹，默认为当前用户
		/// </summary>
		/// <returns></returns>
		public string ClientUserFolder() {
			return ClientUserFolder(CHUser.UserID);
		}
	}
}
