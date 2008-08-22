	using System;
	using System.IO;
	using System.Web;
namespace CHSNS {


	/// <summary>
	/// ͼƬ��С
	/// </summary>
	public enum ImgSize {
		tiny,
		small,
		middle,
		big
		
	}
	/// <summary>
	/// ��ȡ����·������
	/// LE:2007 10 20
	/// </summary>
	public class Path {
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
			return Path.GetFace(userid.ToString(), ImgSize.small);
		}
		public string GetFace_Middle(object userid) {
			return Path.GetFace(userid.ToString(), ImgSize.middle);
		}
		public string GetFace_Big() {
			return GetFace_Big(CHSNSUser.Current.Userid);
		}
		public string GetFace_Big(object userid) {
			return Path.GetFace(userid.ToString(), ImgSize.big);
		}
        public string GetThumbPhoto(long userid,string photofn) {
            return string.Format("{0}{1}.jpg",
                   Path.ClientUserThumbFolder(userid.ToString()),
                   System.IO.Path.GetFileNameWithoutExtension(photofn).ToLower()
                   );
        }
        public string GetPhoto(long userid,string fn) {
            return string.Format("{0}{1}",
                  Path.ClientUserPhotosFolder(userid.ToString()),
                  fn.ToString()
                 );
        }

		public string GroupImg_Big(object groupid) {
			return Path.GetGroupImg(groupid.ToString(), ImgSize.big);
		}
		#region ��ȡ��ҳ�ļ���
		/// <summary>
		/// ��ȡ��ǰҳ�������,��http://aaa.com/x123.html �򷵻�x123
		/// </summary>
		static public string urlFilename {
			get{
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
		/// �õ��û��ļ���
		/// </summary>
		/// <param name="userid">�û�ID</param>
		/// <returns>�û��ļ���</returns>
		static public string ClientUserFolder(string userid) {
			return string.Format("/userFiles/{0}/{1}/{2}/{3}/", new object[] { userid.Substring(userid.Length - 2, 1), userid.Substring(userid.Length - 1, 1), userid.Substring(userid.Length - 3, 1), userid });
		}
		static public string ClientUserFolder(){
			return ClientUserFolder(CHUser.UserID.ToString());
		}
		/// <summary>
		/// �û����·��
		/// </summary>
		/// <returns>��������/userFiles/{0}/{1}/{2}/{3}/photos/�Ľ��</returns>
		static public string ClientUserPhotosFolder(){
			return ClientUserPhotosFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserPhotosFolder(string userid){
			return String.Format("{0}photos/",ClientUserFolder(userid));
		}
		/// <summary>
		/// �û�����ͼ�ļ���·��
		/// </summary>
		/// <returns>����ͼ�ļ���·��</returns>
		static public string ClientUserThumbFolder(){
			return ClientUserThumbFolder(CHUser.UserID.ToString());
		}
		static public string ClientUserThumbFolder(string userid){
			return String.Format("{0}Thumb/",ClientUserFolder(userid));
		}
		#endregion
		#region �û�ͷ��·��
		/// <summary>
		/// �û�ͷ��
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public string GetFace(string userid, ImgSize size) {
			if (userid.Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", ClientUserFolder(userid), userid.Substring(0, 3), size.ToString());
				if (System.IO.File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
					return text;
				}
			}
			return EmptyUserFace(size);
		}
		static private string EmptyUserFace(ImgSize size) {
			return string.Format("/images/no_{0}.jpg", size.ToString());
			//return "/images/no.gif";
		}
		static public string GetFaceEmpty(string userid, ImgSize size) {//���û��ͼƬ�򷵻ؿմ�
			if (userid.Length > 3) {
				string text = string.Format("{0}face/{1}{2}.jpg", ClientUserFolder(userid), userid.Substring(0, 3), size.ToString());
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
		/// <param name="size">ͼƬ��С</param>
		/// <returns>ȺͼƬ·��</returns>
		static public string GetGroupImg(string Groupid, ImgSize size) {
			string text = string.Format("{0}face/{1}{2}.jpg", ClientGroupFolder(Groupid), Groupid, size.ToString());
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
			return GetGroupImg(Groupid, ImgSize.middle);
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
		/// <summary>
		/// �û��ļ���(ASp.net��)
		/// </summary>
		/// <param name="userid">�û�ID</param>
		/// <returns></returns>
		static public string UserFolder(string userid) {
			return string.Format("~{0}", ClientUserFolder(userid));
		}
		#endregion
		
		#region ������������ļ���/�ļ���С
		/// <summary>
		/// �ݹ����ļ��д�С
		/// </summary>
		/// <param name="d"></param>
		/// <returns>�ļ��еĴ�С(�ֽ�)</returns>
		static public long DirectorySize(DirectoryInfo d)
		{
			long Size = 0;
			// �����ļ���С.
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis)
			{
				Size += fi.Length;
			}
			// ��������ǰĿ¼�������ļ���.
			DirectoryInfo[] dis = d.GetDirectories();
			foreach (DirectoryInfo di in dis)
			{
				Size += DirectorySize(di);   //����õ��ݹ��ˣ����ø�����,ע�⣬���ﲢ����ֱ�ӷ���ֵ�����ǵ��ø���������
			}
			return(Size);
		}
		/// <summary>
		/// ��ȡ�ļ���С
		/// </summary>
		/// <param name="path">�ļ�·��</param>
		/// <returns>�ļ��Ĵ�С(�ֽ�)</returns>
		static public long FileSize(string path){
			FileInfo fi   =   new  FileInfo(path);
			return fi.Length;
		}
		#endregion
	}
}
