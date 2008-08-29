	using System;
	using System.IO;
	using System.Web;
namespace CHSNS {

	/// <summary>
	/// 获取各种路径的类
	/// LE:2007 10 20
	/// </summary>
	public class Path {
		#region 新版本的
		#region UserWebPath
		/// <summary>
		/// 得到用户文件夹
		/// </summary>
		/// <param name="userid">用户ID</param>
		/// <returns>用户文件夹</returns>
		static public string UserWebPath(string userid) {
			return string.Format("/userFiles/{0}/", userid.PadLeft(12, '0').Insert(9, "/").Insert(6, "/").Insert(4, "/"));
		}
		static public string UserWebPath() {
			return UserWebPath(CHUser.UserID.ToString());
		}
		#endregion
		#region 
		/// <summary>
		/// 用户文件夹(ASp.net用)
		/// </summary>
		/// <param name="userid">用户ID</param>
		/// <returns></returns>
		static public string UserServerPath(object userid) {
			return string.Format("~{0}", UserWebPath(userid.ToString()));
		}
		static public string FaceMapPath(object userid)
		{
			return ChServer.MapPath(string.Format("{0}face/", UserServerPath(userid)));
		}
		#endregion
		#region GetFace
		/// <summary>
		/// 用户头像
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="sizeType"></param>
		/// <returns></returns>
		static public string GetFace(object userid, ImgSizeType sizeType) {
			string text = string.Format("{0}Face/{1}{2}.jpg",
			                            UserWebPath(userid.ToString()),
			                            userid,
			                            sizeType);
				if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			return EmptyUserFace(sizeType);
		}
		static private string EmptyUserFace(ImgSizeType sizeType) {
			return string.Format("/images/no_{0}.jpg", sizeType);
		}
		#endregion



		#endregion

		//static Path _path;
		static public Path Current {
			get {
				if (HttpContext.Current.Application["path_current"] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application["path_current"] = new Path();
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application["path_current"] as Path;
			}
		}
		public string GetFace_Small(object userid) {
			return Path.GetFace(userid.ToString(), ImgSizeType.Small);
		}
		public string GetFace_Middle(object userid) {
			return Path.GetFace(userid.ToString(), ImgSizeType.Middle);
		}
		public string GetFace_Big() {
			return GetFace_Big(CHSNSUser.Current.UserID);
		}
		public string GetFace_Big(object userid) {
			return Path.GetFace(userid.ToString(), ImgSizeType.Big);
		}
		public string GetThumbPhoto(long userid, string photofn) {
			return string.Format("{0}{1}.jpg",
				   Path.ClientUserThumbFolder(userid.ToString()),
				   System.IO.Path.GetFileNameWithoutExtension(photofn).ToLower()
				   );
		}
		public string GetPhoto(long userid, string fn) {
			return string.Format("{0}{1}",
				  Path.ClientUserPhotosFolder(userid.ToString()),
				  fn.ToString()
				 );
		}

		public string GroupImg_Big(object groupid) {
			return Path.GetGroupImg(groupid.ToString(), ImgSizeType.Big);
		}
		#region 获取网页文件名
		/// <summary>
		/// 获取当前页面的名称,如http://aaa.com/x123.html 则返回x123
		/// </summary>
		static public string urlFilename {
			get {
				return System.IO.Path.GetFileNameWithoutExtension(
					HttpContext.Current.Server.MapPath(HttpContext.Current.Request.Path)
				).ToLower();
			}
		}
		#endregion
		#region 在客户端显示的文件夹 群,用户,图片,缩略图
		/// <summary>
		/// 群组文件夹路径
		/// </summary>
		/// <param name="Groupid">群ID</param>
		/// <returns>文件夹路径</returns>
		static public string ClientGroupFolder(string Groupid) {
			return string.Format("/groupFiles/{0}/", Groupid);
		}
		
		/// <summary>
		/// 用户相册路径
		/// </summary>
		/// <returns>返回形如/userFiles/{0}/{1}/{2}/{3}/photos/的结果</returns>
		static public string ClientUserPhotosFolder() {
			return ClientUserPhotosFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserPhotosFolder(string userid) {
			return String.Format("{0}photos/", UserWebPath(userid));
		}
		/// <summary>
		/// 用户缩略图文件夹路径
		/// </summary>
		/// <returns>缩略图文件夹路径</returns>
		static public string ClientUserThumbFolder() {
			return ClientUserThumbFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserThumbFolder(string userid) {
			return String.Format("{0}Thumb/", UserWebPath(userid));
		}
		#endregion
		#region 用户头像路径

		
		static public string GetFaceEmpty(string userid, ImgSizeType sizeType) {//如果没有图片则返回空串
			if (userid.Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", UserWebPath(userid), userid.Substring(0, 3), sizeType.ToString());
				if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			}
			return String.Empty;
		}
		#endregion
		#region 群图片路径
		/// <summary>
		/// 获取群图片
		/// </summary>
		/// <param name="Groupid">群ID</param>
		/// <param name="sizeType">图片大小</param>
		/// <returns>群图片路径</returns>
		static public string GetGroupImg(string Groupid, ImgSizeType sizeType) {
			string text = string.Format("{0}face/{1}{2}.jpg", ClientGroupFolder(Groupid), Groupid, sizeType.ToString());
			//Debug.Trace(HttpContext.Current.Request.PhysicalApplicationPath + text);
			if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
				return text;
			}
			return "/images/logoMain.jpg";
		}
		/// <summary>
		/// 获取群图片(中号)
		/// </summary>
		/// <param name="Groupid">群ID</param>
		/// <returns>群图片路径</returns>
		static public string GetGroupImg(string Groupid) {
			return GetGroupImg(Groupid, ImgSizeType.Middle);
		}
		public string GetGroupImg(object groupid) {
			return Path.GetGroupImg(groupid.ToString());
		}
		#endregion
		#region 服务器端路径
		/// <summary>
		/// 群文件夹(ASP.net 用)
		/// </summary>
		/// <param name="groupid">群ID</param>
		/// <returns></returns>
		static public string GroupFolder(string groupid) {
			return string.Format("~{0}", ClientGroupFolder(groupid));
		}

		#endregion
		#region 计算服务器上文件夹/文件大小
		/// <summary>
		/// 递归算文件夹大小
		/// </summary>
		/// <param name="d"></param>
		/// <returns>文件夹的大小(字节)</returns>
		static public long DirectorySize(DirectoryInfo d) {
			long Size = 0;
			// 所有文件大小.
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis) {
				Size += fi.Length;
			}
			// 遍历出当前目录的所有文件夹.
			DirectoryInfo[] dis = d.GetDirectories();
			foreach (DirectoryInfo di in dis) {
				Size += DirectorySize(di);   //这就用到递归了，调用父方法,注意，这里并不是直接返回值，而是调用父返回来的
			}
			return (Size);
		}
		/// <summary>
		/// 获取文件大小
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns>文件的大小(字节)</returns>
		static public long FileSize(string path) {
			FileInfo fi = new FileInfo(path);
			return fi.Length;
		}
		#endregion
	}
}
