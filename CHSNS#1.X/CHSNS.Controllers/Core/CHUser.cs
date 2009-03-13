/*
 * Created by 邹健
 * Date: 2007-10-16
 * Time: 10:45
 * 
 * 
 */


namespace CHSNS
{
    using System.Web;

    /// <summary>
    ///  ChSession类
    /// AU:邹健
    /// LE:2007 10 10
    /// </summary>
    public class CHUser : IUser
    {
        /// <summary>
        /// 只有注册时才用的属性
        /// </summary>
        public string Email
        {
            get
            {
                if (HttpContext.Current.Session["email"] != null)
                {
                    return HttpContext.Current.Session["email"].ToString();
                }
                return "未设置";
            }
            set { HttpContext.Current.Session["email"] = value; }
        }

        /// <summary>
        /// 获取当前用户ID,如用户未登录则抛出异常.
        /// </summary>
        public long UserID
        {
            get
            {
                long _Userid = 0;
                if (HttpContext.Current.Session["userid"] != null)
                    long.TryParse(HttpContext.Current.Session["userid"].ToString(), out _Userid);
                return _Userid;
            }
            set { HttpContext.Current.Session["userid"] = value; }
        }

        /// <summary>
        /// 获取当前用户姓名
        /// </summary>
        public string Username
        {
            get
            {
                if (HttpContext.Current.Session["username"] != null)
                    return HttpContext.Current.Session["username"].ToString();
                return "未设置";
            }
            set { HttpContext.Current.Session.Add("username", value); }
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        /// <param name="status"></param>
        public void InitStatus(object status)
        {
            HttpContext.Current.Session.Add("status", status);
        }

        /// <summary>
        /// 获取当前用户状态
        /// </summary>
        public Role Status
        {
            get
            {
                int status = 0;
                if (HttpContext.Current.Session["status"] != null)
                    int.TryParse(HttpContext.Current.Session["status"].ToString(), out status);
                return new Role(status);
            }

        }
        /// <summary>
        /// 用户是否是管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return Status.Contains(RoleType.Creater, RoleType.Editor);
            }
        }
        /// <summary>
        /// 用户是否登录
        /// </summary>
        public bool IsLogin
        {
            get
            {
                return Status.IsLogin;
            }
        }

        /// <summary>
        /// 等 同 RemoveAll
        /// </summary>
        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}