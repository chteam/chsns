using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
namespace CHSNS {


	/// <summary>
	/// ����
	/// </summary>
	public class Online : IOnline {
        public Online(IContext context)
        {
            Context = context;
        }
		private const string ONLINE_REMOVETIME = "useronline.time";
		private const string ONLINE_LIST = "useronline";
		/// <summary>
		/// ���������û�
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
		/// ��������û������
		/// </summary>
		 public void Update() {
             if (Context.User.IsLogin)
             {
				if (Date.DivMinutes(RemoveTime) > 1) {//����1���Ӳ�����
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
		#region �û��Ƿ�����
		public bool IsOnline(long userid) {
			return Items.ContainsKey(userid);
		}
		#endregion

		/// <summary>
		/// ��ȡ�����û��б�
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
