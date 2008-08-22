/*
 * Created by 邹健
 * Date: 2007-10-16
 * Time: 10:45
 * 
 * 
 */
namespace CHSNS
{

	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;

	using Chsword;

	/// <summary>
	///  ChSession类
	/// AU:邹健
	/// LE:2007 10 10
	/// </summary>
	public partial class CHUser
	{
		/// <summary>
		/// 只有注册时才用的属性
		/// </summary>
		static public string Email {
			get {
				if (HttpContext.Current.Session["email"] != null) {
					return HttpContext.Current.Session["email"].ToString();
				}
				return "未设置";
			}
			set {

				HttpContext.Current.Session["email"] = value;
			}
		}
		/// <summary>
		/// 获取当前用户ID,如用户未登录则抛出异常.
		/// </summary>
		static public long UserID {
			get {
				if (HttpContext.Current.Session["userid"] != null) {
					long _Userid = 0;
					if (long.TryParse(HttpContext.Current.Session["userid"].ToString(), out _Userid))
						return _Userid;
				}
				throw new Exception("请先登录 palease login first.");
			}
			set {
				HttpContext.Current.Session["userid"] = value;
			}
		}
		/// <summary>
		/// 获取当前用户ID,如果未登录则返回0
		/// </summary>
		static public long UseridwithoutError {
			get {
				long _Userid = 0;
				if (HttpContext.Current.Session["userid"] != null) {
					if (long.TryParse(HttpContext.Current.Session["userid"].ToString(), out _Userid))
						return _Userid;
				}
				return 0;
			}
		}
		/// <summary>
		/// 获取当前用户姓名
		/// </summary>
		static public string Username {
			get {
				if (HttpContext.Current.Session["username"] != null) {
					return HttpContext.Current.Session["username"].ToString();
				}
				return "未设置";
			}
			set {
				HttpContext.Current.Session.Add("username", value);
			}
		}
		/// <summary>
		/// 初始化状态
		/// </summary>
		/// <param name="status"></param>
		static public void InitStatus(object status) {
			HttpContext.Current.Session.Add("status", status);
		}
		/// <summary>
		/// 获取当前用户状态
		/// </summary>
		static public byte Status {
			get {
				if (HttpContext.Current.Session["userid"] != null) {
					byte status = 0;
					if (byte.TryParse(HttpContext.Current.Session["status"].ToString(), out status))
						return status;
				}
				return 0;
			}
			set {
				HttpContext.Current.Session["status"] = value;
				if (HttpContext.Current.Session["userid"] != null) {
					SqlParameter[] sp = new SqlParameter[2] { 
							new SqlParameter("@Userid", SqlDbType.BigInt),
							new SqlParameter("@status", SqlDbType.TinyInt),
					};
					sp[0].Value = CHUser.UserID;
					sp[1].Value = value;
					DoDataBase db = new DoDataBase();
					db.ExecuteSql("Status_Update", sp);
				}
			}
		}
		static public bool IsAdmin {
			get {
				return Status > 199;
			}
		}
		static public bool IsLogin {
			get {
				return CHUser.UseridwithoutError != 0;
			}
		}
		static public int unReadMessage {
			get {
				string name = string.Format("unReadMessage.{0}", UserID);
				if (ChCache.IsNullorEmpty(name) || ChCache.GetCache(name).ToString() == "0") {
					SqlParameter[] sp = new SqlParameter[1] { 
					        new SqlParameter("@userid", SqlDbType.BigInt)
					};
					sp[0].Value = CHUser.UserID;
					DoDataBase db = new DoDataBase();
					ChCache.SetCache(name,
						db.DoDataTable("unSee_Countlist", sp).Rows[0][0],
						new TimeSpan(0, 2, 0)
						);
				}
				return (int)ChCache.GetCache(name);
			}

		}
		/// <summary>
		/// 等 同 RemoveAll
		/// </summary>
		static public void Clear() {
			HttpContext.Current.Session.Clear();
		}
	}
}
