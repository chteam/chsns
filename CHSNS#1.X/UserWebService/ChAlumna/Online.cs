using System;
using System.Collections.Generic;
using System.Web;

using Chsword;
namespace CHSNS {


	public class Online {
		/// <summary>
		/// ���������û�
		/// </summary>
		static public void RemoveOffline() {
			if (CHUser.UserID > 0) {
				List<long> userid = new List<long>();
				foreach (long u in OnlineList.Keys){
					if (Date.DivMinutes(OnlineList[u]) > 10) {
						userid.Add(u);
					}
				}
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
			if (CHUser.UserID > 0) {
				if (Date.DivMinutes(RemoveTime) > 1) {//����1���Ӳ�����
					HttpContext.Current.Application.Lock();
					if (!OnlineList.ContainsKey(CHUser.UserID))
						OnlineList.Add(CHUser.UserID, DateTime.Now);
					else
						OnlineList[CHUser.UserID] = DateTime.Now;
					RemoveTime = DateTime.Now;
					HttpContext.Current.Application.UnLock();
				}
			}
		}
		#region �û��Ƿ�����
		static public bool isOnline(long userid) {
			return OnlineList.ContainsKey(userid);
		}
		static public bool isOnline(object userid) {
			long u = 0;
			if (long.TryParse(userid.ToString(), out u))
				return isOnline(u);
			return false;
		}
		static public string OnlineString(long userid) {
			if (isOnline(userid))
				return ChCache.GetConfig("Profile","Online");
			return ChCache.GetConfig("Profile","Offline");
		}
		static public string OnlineString(object userid) {
			long u = 0;
			if (long.TryParse(userid.ToString(), out u))
				return OnlineString(u);
			return "";
		}
		#endregion
		/// <summary>
		/// ��ȡ�����û��б�
		/// </summary>
		static public Dictionary<long, DateTime> OnlineList {
			get {
				if (HttpContext.Current.Application["useronline"] == null){
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application["useronline"] = new Dictionary<long, DateTime>();
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application["useronline"] as Dictionary<long, DateTime>;
			}
			set {
				//HttpContext.Current.Application.Add("useronline", list);
			}
		}
		static DateTime RemoveTime {
			get {
			//	Hashtable
				if (HttpContext.Current.Application["useronline.time"] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application["useronline.time"] = new DateTime();
					HttpContext.Current.Application.UnLock();
				}
				return Convert.ToDateTime(HttpContext.Current.Application["useronline.time"]);
			}
			set {
				HttpContext.Current.Application.Add("useronline.time", value);
			}
		}
	}
}
