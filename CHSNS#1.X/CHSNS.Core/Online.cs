using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
namespace CHSNS {


	/// <summary>
	/// ����
	/// </summary>
	public class Online {
		static readonly string ONLINE_REMOVETIME = "useronline.time";
		static readonly string ONLINE_LIST = "useronline";
		/// <summary>
		/// ���������û�
		/// </summary>
		static public void RemoveOffline() {
			if (CHUser.IsLogin) {
				var expies = DateTime.Now.AddMinutes(-10);
				List<long> userid = OnlineList
					.Where(c => c.Value < expies)
					.Select(c => c.Key).ToList();
				HttpContext.Current.Application.Lock();
				foreach (long u in userid) {
					OnlineList.Remove(u);
				}
				HttpContext.Current.Application.UnLock();
			}
		}
		/// <summary>
		/// ��������û������
		/// </summary>
		static public void Update() {
			if ( CHUser.IsLogin) {
				if (Date.DivMinutes(RemoveTime) > 1) {//����1���Ӳ�����
					HttpContext.Current.Application.Lock();
					if (!IsOnline(CHUser.UserID))
						OnlineList.Add(CHUser.UserID, DateTime.Now);
					else
						OnlineList[CHUser.UserID] = DateTime.Now;
					RemoveTime = DateTime.Now;
					HttpContext.Current.Application.UnLock();
				}
			}
		}
		#region �û��Ƿ�����
		static public bool IsOnline(long userid) {
			return OnlineList.ContainsKey(userid);
		}
		#endregion

		/// <summary>
		/// ��ȡ�����û��б�
		/// </summary>
		static public Dictionary<long, DateTime> OnlineList {
			get {
				if (Application[ONLINE_LIST] == null) {
					Application.Lock();
					Application[ONLINE_LIST] = new Dictionary<long, DateTime>();
					Application.UnLock();
				}
				return Application[ONLINE_LIST] as Dictionary<long, DateTime>;
			}
		}
		
		static DateTime RemoveTime {
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
	}
}
