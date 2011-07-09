using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
namespace CHSNS {
    using System.ComponentModel.Composition;
    using Interface;

    /// <summary>
    /// 在线
    /// </summary>
    [Export]
    public class Online : IOnline {
        
        private const string OnlineRemovetime = "useronline.time";
        private const string OnlineList = "useronline";
        /// <summary>
        /// 清理离线用户
        /// </summary>
        public void RemoveOffline()
        {
            var expies = DateTime.Now.AddMinutes(-10);
            List<long> userid = Items
                .Where(c => c.Value < expies)
                .Select(c => c.Key).ToList();
            Application.Lock();
            foreach (long u in userid)
            {
                Items.Remove(u);
            }
           Application.UnLock();
        }
        /// <summary>
        /// 添加在线用户或更新
        /// </summary>
         public void Update() {
             if (HttpContext.Current.User.Identity.IsAuthenticated)
             {
                 var user = HttpContext.Current.User.Identity as WebIdentity;
                if (Date.DivMinutes(RemoveTime) > 1) {//过了1分钟才清理
                    Application.Lock();
                    if (user != null)
                        if (!IsOnline(user.UserId))
                            Items.Add(user.UserId, DateTime.Now);
                        else
                            Items[user.UserId] = DateTime.Now;
                    RemoveTime = DateTime.Now;
                    Application.UnLock();
                }
                RemoveOffline();
            }
        }
        #region 用户是否在线
        public bool IsOnline(long userid) {
            return Items.ContainsKey(userid);
        }
        #endregion

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
         public Dictionary<long, DateTime> Items {
            get {
                if (Application[OnlineList] == null) {
                    Application.Lock();
                    Application[OnlineList] = new Dictionary<long, DateTime>();
                    Application.UnLock();
                }
                return Application[OnlineList] as Dictionary<long, DateTime>;
            }
        }
        
         DateTime RemoveTime {
            get {
            //	Hashtable
                if (Application[OnlineRemovetime] == null) {
                    Application.Lock();
                    Application[OnlineRemovetime] = new DateTime();
                    Application.UnLock();
                }
                return Convert.ToDateTime(Application[OnlineRemovetime]);
            }
            set {
                Application.Add(OnlineRemovetime, value);
            }
        }

        HttpApplicationStateBase Application {
            get { return new HttpApplicationStateWrapper(HttpContext.Current.Application); }
        }


      
         
    }
}
