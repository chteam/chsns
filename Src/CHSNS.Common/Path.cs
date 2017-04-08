using System;
namespace CHSNS
{
    /// <summary>
    /// ��ȡ����·������
    /// LE:2007 10 20
    /// </summary>
    public class Path
    {
        #region ���

        #region ͼƬ

        public static string PhotoPath(DateTime dt)
        {
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
        public static string Photo(long UserID, DateTime dt, string ext, string size)
        {
            return string.Format("{0}/{1}{2}{4}{3}",
                                 PhotoPath(dt), UserID, dt.Ticks/1000000, ext, size);
        }

        //public static string Photo(long UserID, DateTime dt, string ext, ThumbType t)
        //{
        //    return Photo(UserID, dt, ext, t.ToString());
        //}

        #endregion

        #region ���

        public static string AlbumFace(string url)
        {
            throw new NotImplementedException();
            // return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) ? url : EmptyImage(ThumbType.Middle);
        }

        #endregion

        #endregion

        #region Style

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


        #region GetFace

        /// <summary>
        /// �û�ͷ��
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        //public static string GetFace(object userid, ThumbType type)
        //{
        //    string text = string.Format("{0}Face/{1}{2}.jpg",
        //                                UserWebPath(userid.ToString()),
        //                                userid,
        //                                type);
        //    //if (IOFactory.StoreFile.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
        //    return text;
        //    //	}
        //    //return EmptyImage(type);
        //}

        //private static string EmptyImage(ThumbType type)
        //{
        //    return string.Format("/images/no_{0}.jpg", type);
        //}

        #endregion

        #endregion

        #region Face

        //static Path _path;
        public static Path Current
        {
            get
            {
                //if (HttpContext.Current.Application["path_current"] == null)
                //{
                //    HttpContext.Current.Application.Lock();
                //    HttpContext.Current.Application["path_current"] = new Path();
                //    HttpContext.Current.Application.UnLock();
                //}
                //return HttpContext.Current.Application["path_current"] as Path;
                throw new NotImplementedException();
            }
        }

        public string GetFace_Small(object userid)
        {
            throw new NotImplementedException();
            //return GetFace(userid.ToString(), ThumbType.Small);
        }

        public string GetFace_Middle(object userid)
        {
            throw new NotImplementedException();
            //return GetFace(userid.ToString(), ThumbType.Middle);
        }

        //public string GetFace_Big() {
        //    return GetFace_Big(CHUser.UserId);
        //}
        public string GetFace_Big(object userid)
        {
            throw new NotImplementedException();
            //return GetFace(userid.ToString(), ThumbType.Big);
        }

        public string GetThumbPhoto(long userid, string photofn)
        {
            return string.Format("{0}{1}.jpg",
                                 ClientUserThumbFolder(userid.ToString()),
                                 System.IO.Path.GetFileNameWithoutExtension(photofn).ToLower()
                );
        }

        public string GetPhoto(long userid, string fn)
        {
            return string.Format("{0}{1}",
                                 ClientUserPhotosFolder(userid.ToString()),
                                 fn
                );
        }

        public string GroupImg_Big(object groupid)
        {
            throw new NotImplementedException();
            //return GetGroupImg(groupid.ToString(), ThumbType.Big);
        }

        public static string GetRoot()
        {
            return "/";
        }

        /// <summary>
        /// ϵͳ�¼�ģ��Ŀ¼
        /// </summary>
        /// <returns></returns>
        public static string EventSystemTemplatePath(string name)
        {
            return string.Format("{0}Views/Shared/EventTemplate/{1}.ascx", GetRoot(), name);
        }

        #endregion

        #region ��ȡ��ҳ�ļ���

        /// <summary>
        /// ��ȡ��ǰҳ�������,��http://aaa.com/x123.html �򷵻�x123
        /// </summary>
        public static string urlFilename
        {
            get
            {
                //return System.IO.Path.GetFileNameWithoutExtension(
                //    HttpContext.Current.Server.MapPath(HttpContext.Current.Request.Path)
                //    ).ToLower();
                throw new NotImplementedException();
            }
        }

        #endregion

        #region �ڿͻ�����ʾ���ļ��� Ⱥ,�û�,ͼƬ,����ͼ

        /// <summary>
        /// Ⱥ���ļ���·��
        /// </summary>
        /// <param name="Groupid">ȺID</param>
        /// <returns>�ļ���·��</returns>
        public static string ClientGroupFolder(object Groupid)
        {
            return string.Format("/groupFiles/{0}/", Groupid);
        }

        ///// <summary>
        ///// �û����·��
        ///// </summary>
        ///// <returns>��������/userFiles/{0}/{1}/{2}/{3}/photos/�Ľ��</returns>
        //static public string ClientUserPhotosFolder() {
        //    return ClientUserPhotosFolder(CHUser.UserId.ToString());
        //}
        public static string ClientUserPhotosFolder(string userid)
        {
            //  return String.Format("{0}photos/", UserWebPath(userid));
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// �û�����ͼ�ļ���·��
        ///// </summary>
        ///// <returns>����ͼ�ļ���·��</returns>
        //static public string ClientUserThumbFolder() {
        //    return ClientUserThumbFolder(CHUser.UserId.ToString());
        //}
        public static string ClientUserThumbFolder(string userid)
        {
            throw new NotImplementedException();
            //  return String.Format("{0}Thumb/", UserWebPath(userid));
        }

        #endregion

        #region �û�ͷ��·��

//        public static string GetFaceEmpty(string userid, ThumbType type)
//        {
////���û��ͼƬ�򷵻ؿմ�
//            if (userid.Length > 3)
//            {
//                string text = string.Format("{0}face/{1}{2}.jpg", UserWebPath(userid), userid.Substring(0, 3), type);
//                //      if (IOFactory.StoreFile.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
//                return text;
//                //		}
//            }
//            return String.Empty;
//        }

        #endregion

        #region ȺͼƬ·��

        /// <summary>
        /// ��ȡȺͼƬ
        /// </summary>
        /// <param name="groupId">ȺID</param>
        /// <param name="type">ͼƬ��С</param>
        /// <returns>ȺͼƬ·��</returns>
        //public static string GetGroupImg(object groupId, ThumbType type)
        //{
        //    string text = string.Format("{0}face/{1}{2}.jpg", ClientGroupFolder(groupId), groupId, type);
        //    //Debug.Trace(HttpContext.Current.Request.PhysicalApplicationPath + text);
        //    // if (IOFactory.StoreFile.Exists(HttpContext.Current.Request.PhysicalApplicationPath + text)) {
        //    return text;
        //    //}
        //    //return "/images/logoMain.jpg";
        //}

        /// <summary>
        /// ��ȡȺͼƬ(�к�)
        /// </summary>
        /// <returns>ȺͼƬ·��</returns>
        public static string GetGroupImg(string groupId)
        {
            throw new NotImplementedException();
            // return GetGroupImg(groupId, ThumbType.Middle);
        }

        public string GetGroupImg(object groupId)
        {
            return GetGroupImg(groupId.ToString());
        }

        #endregion

        #region ��������·��

        /// <summary>
        /// Ⱥ�ļ���(ASP.net ��)
        /// </summary>
        /// <param name="groupid">ȺID</param>
        /// <returns></returns>
        public static string GroupFolder(string groupid)
        {
            return string.Format("~{0}", ClientGroupFolder(groupid));
        }

        #endregion

 
    }
}