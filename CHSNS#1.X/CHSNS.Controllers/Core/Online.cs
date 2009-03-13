using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
namespace CHSNS {


	/// <summary>
	/// 在线
	/// </summary>
	public class Online : IOnline {
        public Online(IContext context)
        {
            Context = context;
        }
		private const string ONLINE_REMOVETIME = "useronline.time";
		private const string ONLINE_LIST = "useronline";
		/// <summary>
		/// 清理离线用户
		/// </summary>
        public void RemoveOffline()
        {
            var expies = DateTime.Now.AddMinutes(-10);
            List<long> userid = Items
                .Where(c => c.Value < expies)
                .Select(c => c.Key).ToList();
            HttpContext.Current.Application.Lock();
            foreach (long u in userid)
            {
                Items.Remove(u);
            }
            HttpContext.Current.Application.UnLock();
        }
		/// <summary>
		/// 添加在线用户或更新
		/// </summary>
		 public void Update() {
             if (Context.User.IsLogin)
             {
				if (Date.DivMinutes(RemoveTime) > 1) {//过了1分钟才清理
					HttpContext.Current.Application.Lock();
                    if (!IsOnline(Context.User.UserID))
                        Items.Add(Context.User.UserID, DateTime.Now);
					else
                        Items[Context.User.UserID] = DateTime.Now;
					RemoveTime = DateTime.Now;
					HttpContext.Current.Application.UnLock();
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
				if (Application[ONLINE_LIST] == null) {
					Application.Lock();
					Application[ONLINE_LIST] = new Dictionary<long, DateTime>();
					Application.UnLock();
				}
				return Application[ONLINE_LIST] as Dictionary<long, DateTime>;
			}
		}
		
		 DateTime RemoveTime {
			get {
			//	Hashtable
				if (Application[ONLINE_REMOVETIME] == null) {
					Application.Lock();
					Application[ONLINE_REMOVETIME] = new DateTime();
					Application.UnLock();
				}
				return Convert.ToDateTime(Application[ONLINE_REMOVETIME]);
			}
			set {
				Application.Add(ONLINE_REMOVETIME, value);
			}
		}

	    static HttpApplicationState Application {
			get { return HttpContext.Current.Application; }
		}


         public IContext Context { get; set; }
         
    }
}
