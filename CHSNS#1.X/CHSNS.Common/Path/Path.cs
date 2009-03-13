	using System;
	using System.IO;
	using System.Web;
namespace CHSNS {

	/// <summary>
	/// ��ȡ����·������
	/// LE:2007 10 20
	/// </summary>
	public class Path {
		#region ���
		#region ͼƬ
		static public string PhotoPath(DateTime dt) {
			return string.Format("/photos/{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
		}
		/// <summary>
		/// size is s t m b or source
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="dt"></param>
		/// <param name="ext"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public string Photo(long UserID, DateTime dt, string ext, string size) {
			return string.Format("{0}/{1}{2}{4}{3}",
			                     PhotoPath(dt), UserID, dt.Ticks/1000000, ext, size);
		}
		static public string Photo(long UserID, DateTime dt, string ext, ThumbType t){
			return Photo(UserID, dt, ext, t.ToString());
		}


		#endregion
		#region ���
		static public string AlbumFace(string url)
		{
		    return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) ? url : EmptyImage(ThumbType.Middle);
		}

	    #endregion
		#endregion

		#region Style
		/// <summary>
		/// like /style/facebook/images/1.jpg
		/// </summary>
		/// <param name="fn"></param>
		/// <returns></returns>
        //public static string ImageInStyle(string fn) {
        //    return string.Format(
        //        "{0}Style/{1}/images/{2}"
        //        , CHSite.BaseConfig.Path
        //        , CHSite.BaseConfig.Style, fn)
        //        .Replace("\\", "/")
        //        .Replace("//", "/");
        //}
		#endregion

		#region �°汾��
		#region UserWebPath
		/// <summary>
		/// �õ��û��ļ���
		/// </summary>
		/// <param name="userid">�û�ID</param>
		/// <returns>�û��ļ���</returns>
		static public string UserWebPath(string userid) {
			return string.Format("/userFiles/{0}/", userid.PadLeft(12, '0').Insert(9, "/").Insert(6, "/").Insert(4, "/"));
		}
        //static public string UserWebPath() {
        //    return UserWebPath(CHUser.UserID.ToString());
        //}
		#endregion
		#region 
		/// <summary>
		/// �û��ļ���(ASp.net��)
		/// </summary>
		/// <param name="userid">�û�ID</param>
		/// <returns></returns>
		static public string UserServerPath(object userid) {
			return string.Format("~{0}", UserWebPath(userid.ToString()));
		}
		static public string FaceMapPath(object userid)
		{
			return HttpContext.Current.Server.MapPath(string.Format("{0}face/", UserServerPath(userid)));
		}
		#endregion
		#region GetFace
		/// <summary>
		/// �û�ͷ��
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		static public string GetFace(object userid, ThumbType type) {
			string text = string.Format("{0}Face/{1}{2}.jpg",
			                            UserWebPath(userid.ToString()),
			                            userid,
			                            type);
				if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			return EmptyImage(type);
		}
		static private string EmptyImage(ThumbType type) {
			return string.Format("/images/no_{0}.jpg", type);
		}
		#endregion



		#endregion
		#region Face

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
			return GetFace(userid.ToString(), ThumbType.Small);
		}
		public string GetFace_Middle(object userid) {
			return GetFace(userid.ToString(), ThumbType.Middle);
		}
        //public string GetFace_Big() {
        //    return GetFace_Big(CHUser.UserID);
        //}
		public string GetFace_Big(object userid) {
			return GetFace(userid.ToString(), ThumbType.Big);
		}
		public string GetThumbPhoto(long userid, string photofn) {
			return string.Format("{0}{1}.jpg",
				   ClientUserThumbFolder(userid.ToString()),
				   System.IO.Path.GetFileNameWithoutExtension(photofn).ToLower()
				   );
		}
		public string GetPhoto(long userid, string fn) {
			return string.Format("{0}{1}",
				  ClientUserPhotosFolder(userid.ToString()),
				  fn
				 );
		}

		public string GroupImg_Big(object groupid) {
			return GetGroupImg(groupid.ToString(), ThumbType.Big);
		}
		static public string GetRoot() {
			return "/";
		}
		/// <summary>
		/// ϵͳ�¼�ģ��Ŀ¼
		/// </summary>
		/// <returns></returns>
		public static string EventSystemTemplatePath(string name) {
			return string.Format("{0}Views/Shared/EventTemplate/{1}.ascx", GetRoot(), name);
		}

		#endregion
		#region ��ȡ��ҳ�ļ���
		/// <summary>
		/// ��ȡ��ǰҳ�������,��http://aaa.com/x123.html �򷵻�x123
		/// </summary>
		static public string urlFilename {
			get {
				return System.IO.Path.GetFileNameWithoutExtension(
					HttpContext.Current.Server.MapPath(HttpContext.Current.Request.Path)
				).ToLower();
			}
		}
		#endregion
		#region �ڿͻ�����ʾ���ļ��� Ⱥ,�û�,ͼƬ,����ͼ
		/// <summary>
		/// Ⱥ���ļ���·��
		/// </summary>
		/// <param name="Groupid">ȺID</param>
		/// <returns>�ļ���·��</returns>
		static public string ClientGroupFolder(object Groupid) {
			return string.Format("/groupFiles/{0}/", Groupid);
		}
		
        ///// <summary>
        ///// �û����·��
        ///// </summary>
        ///// <returns>��������/userFiles/{0}/{1}/{2}/{3}/photos/�Ľ��</returns>
        //static public string ClientUserPhotosFolder() {
        //    return ClientUserPhotosFolder(CHUser.UserID.ToString());
        //}
		static public string ClientUserPhotosFolder(string userid) {
			return String.Format("{0}photos/", UserWebPath(userid));
		}
        ///// <summary>
        ///// �û�����ͼ�ļ���·��
        ///// </summary>
        ///// <returns>����ͼ�ļ���·��</returns>
        //static public string ClientUserThumbFolder() {
        //    return ClientUserThumbFolder(CHUser.UserID.ToString());
        //}
		static public string ClientUserThumbFolder(string userid) {
			return String.Format("{0}Thumb/", UserWebPath(userid));
		}
		#endregion
		#region �û�ͷ��·��

		
		static public string GetFaceEmpty(string userid, ThumbType type) {//���û��ͼƬ�򷵻ؿմ�
			if (userid.Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", UserWebPath(userid), userid.Substring(0, 3), type);
				if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			}
			return String.Empty;
		}
		#endregion
		#region ȺͼƬ·��
		/// <summary>
		/// ��ȡȺͼƬ
		/// </summary>
		/// <param name="Groupid">ȺID</param>
		/// <param name="type">ͼƬ��С</param>
		/// <returns>ȺͼƬ·��</returns>
		static public string GetGroupImg(object Groupid, ThumbType type) {
			string text = string.Format("{0}face/{1}{2}.jpg", ClientGroupFolder(Groupid), Groupid, type);
			//Debug.Trace(HttpContext.Current.Request.PhysicalApplicationPath + text);
			if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
				return text;
			}
			return "/images/logoMain.jpg";
		}
		/// <summary>
		/// ��ȡȺͼƬ(�к�)
		/// </summary>
		/// <param name="Groupid">ȺID</param>
		/// <returns>ȺͼƬ·��</returns>
		static public string GetGroupImg(string Groupid) {
			return GetGroupImg(Groupid, ThumbType.Middle);
		}
		public string GetGroupImg(object groupid) {
			return GetGroupImg(groupid.ToString());
		}
		#endregion
		#region ��������·��
		/// <summary>
		/// Ⱥ�ļ���(ASP.net ��)
		/// </summary>
		/// <param name="groupid">ȺID</param>
		/// <returns></returns>
		static public string GroupFolder(string groupid) {
			return string.Format("~{0}", ClientGroupFolder(groupid));
		}

		#endregion
		#region ������������ļ���/�ļ���С
		/// <summary>
		/// �ݹ����ļ��д�С
		/// </summary>
		/// <param name="d"></param>
		/// <returns>�ļ��еĴ�С(�ֽ�)</returns>
		static public long DirectorySize(DirectoryInfo d) {
			long Size = 0;
			// �����ļ���С.
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis) {
				Size += fi.Length;
			}
			// ��������ǰĿ¼�������ļ���.
			DirectoryInfo[] dis = d.GetDirectories();
			foreach (DirectoryInfo di in dis) {
				Size += DirectorySize(di);   //����õ��ݹ��ˣ����ø�����,ע�⣬���ﲢ����ֱ�ӷ���ֵ�����ǵ��ø���������
			}
			return (Size);
		}
		/// <summary>
		/// ��ȡ�ļ���С
		/// </summary>
		/// <param name="path">�ļ�·��</param>
		/// <returns>�ļ��Ĵ�С(�ֽ�)</returns>
		static public long FileSize(string path) {
			FileInfo fi = new FileInfo(path);
			return fi.Length;
		}
		#endregion
	}
}
