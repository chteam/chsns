using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web;

namespace CHSNS
{
	public class CHIdentity : IIdentity, IUser
	{
		public CHIdentity(IUser user)
		{
				
		}
 
		#region IIdentity Members

		public string AuthenticationType
		{
			get;
			set;
		}

		public bool IsAuthenticated
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		#endregion

		#region IUser Members

		public void Clear()
		{
			//Context.Session.Clear();
		}

		public string Email { get; set; }

		public void InitStatus(object status)
		{
			//Context.Session.Add("status", status);
		}

		/// <summary>
		/// 获取当前用户状态
		/// </summary>
		public Role Status
		{
			get;
			set;
		}

		public bool IsAdmin
		{
			get { return Status.Contains(RoleType.Creater, RoleType.Editor); }
		}

		public bool IsLogin
		{
			get { return Status.IsLogin; }
		}

		//public Role Status { get; set; }

		public long UserId { get; set; }

		public string NickName { get; set; }

		#endregion
	}
}
