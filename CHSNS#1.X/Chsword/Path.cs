	using System;
	using System.IO;
	using System.Web;
namespace CHSNS {

	/// <summary>
	/// ��ȡ����·������
	/// LE:2007 10 20
	/// </summary>
	public class Path {
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
		static public string UserWebPath() {
			return UserWebPath(CHUser.UserID.ToString());
		}
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
			return CHServer.MapPath(string.Format("{0}face/", UserServerPath(userid)));
		}
		#endregion
		#region GetFace
		/// <summary>
		/// �û�ͷ��
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
		static public string ClientGroupFolder(string Groupid) {
			return string.Format("/groupFiles/{0}/", Groupid);
		}
		
		/// <summary>
		/// �û����·��
		/// </summary>
		/// <returns>��������/userFiles/{0}/{1}/{2}/{3}/photos/�Ľ��</returns>
		static public string ClientUserPhotosFolder() {
			return ClientUserPhotosFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserPhotosFolder(string userid) {
			return String.Format("{0}photos/", UserWebPath(userid));
		}
		/// <summary>
		/// �û�����ͼ�ļ���·��
		/// </summary>
		/// <returns>����ͼ�ļ���·��</returns>
		static public string ClientUserThumbFolder() {
			return ClientUserThumbFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserThumbFolder(string userid) {
			return String.Format("{0}Thumb/", UserWebPath(userid));
		}
		#endregion
		#region �û�ͷ��·��

		
		static public string GetFaceEmpty(string userid, ImgSizeType sizeType) {//���û��ͼƬ�򷵻ؿմ�
			if (userid.Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", UserWebPath(userid), userid.Substring(0, 3), sizeType.ToString());
				if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
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
		/// <param name="sizeType">ͼƬ��С</param>
		/// <returns>ȺͼƬ·��</returns>
		static public string GetGroupImg(string Groupid, ImgSizeType sizeType) {
			string text = string.Format("{0}face/{1}{2}.jpg", ClientGroupFolder(Groupid), Groupid, sizeType.ToString());
			//Debug.Trace(HttpContext.Current.Request.PhysicalApplicationPath + text);
			if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
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
			return GetGroupImg(Groupid, ImgSizeType.Middle);
		}
		public string GetGroupImg(object groupid) {
			return Path.GetGroupImg(groupid.ToString());
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