using System;
namespace CHSNS
{
    /// <summary>
    /// 获取各种路径的类
    /// LE:2007 10 20
    /// </summary>
    public class Path
    {
        #region 相册

        #region 图片

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

        #region 相册

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

        #region 新版本的


        #region GetFace

        /// <summary>
        /// 用户头像
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
        /// 系统事件模板目录
        /// </summary>
        /// <returns></returns>
        public static string EventSystemTemplatePath(string name)
        {
            return string.Format("{0}Views/Shared/EventTemplate/{1}.ascx", GetRoot(), name);
        }

        #endregion

        #region 获取网页文件名

        /// <summary>
        /// 获取当前页面的名称,如http://aaa.com/x123.html 则返回x123
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

        #region 在客户端显示的文件夹 群,用户,图片,缩略图

        /// <summary>
        /// 群组文件夹路径
        /// </summary>
        /// <param name="Groupid">群ID</param>
        /// <returns>文件夹路径</returns>
        public static string ClientGroupFolder(object Groupid)
        {
            return string.Format("/groupFiles/{0}/", Groupid);
        }

        ///// <summary>
        ///// 用户相册路径
        ///// </summary>
        ///// <returns>返回形如/userFiles/{0}/{1}/{2}/{3}/photos/的结果</returns>
        //static public string ClientUserPhotosFolder() {
        //    return ClientUserPhotosFolder(CHUser.UserId.ToString());
        //}
        public static string ClientUserPhotosFolder(string userid)
        {
            //  return String.Format("{0}photos/", UserWebPath(userid));
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 用户缩略图文件夹路径
        ///// </summary>
        ///// <returns>缩略图文件夹路径</returns>
        //static public string ClientUserThumbFolder() {
        //    return ClientUserThumbFolder(CHUser.UserId.ToString());
        //}
        public static string ClientUserThumbFolder(string userid)
        {
            throw new NotImplementedException();
            //  return String.Format("{0}Thumb/", UserWebPath(userid));
        }

        #endregion

        #region 用户头像路径

//        public static string GetFaceEmpty(string userid, ThumbType type)
//        {
////如果没有图片则返回空串
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

        #region 群图片路径

        /// <summary>
        /// 获取群图片
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="type">图片大小</param>
        /// <returns>群图片路径</returns>
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
        /// 获取群图片(中号)
        /// </summary>
        /// <returns>群图片路径</returns>
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

        #region 服务器端路径

        /// <summary>
        /// 群文件夹(ASP.net 用)
        /// </summary>
        /// <param name="groupid">群ID</param>
        /// <returns></returns>
        public static string GroupFolder(string groupid)
        {
            return string.Format("~{0}", ClientGroupFolder(groupid));
        }

        #endregion

 
    }
}