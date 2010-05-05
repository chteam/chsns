using System;
using System.Collections.Generic;
using System.Linq;

namespace CHSNS {
	public class Role {
		private RoleType _RoleType = RoleType.Anonymous;
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="role"></param>
		public Role(object role) {
			if (role != null)
				_RoleType = (RoleType)role;
		}
		/// <summary>
		/// 当前类封装的roleType
		/// </summary>
		public RoleType RoleType {
			get { return _RoleType; }
			set { _RoleType = value; }
		}
		/// <summary>
		/// 当前的role对象是否包含某个TYPE
		/// </summary>
		/// <param name="rt"></param>
		/// <returns></returns>
		public bool Contains(RoleType rt) {
			return (_RoleType & rt) == rt;
		}

		public bool Contains(params RoleType[] rt) {
			return Contains(rt.ToList());
		}
		/// <summary>
		/// 当前的role对象是否包含某些TYPE
		/// </summary>
		/// <param name="rts"></param>
		/// <returns></returns>
		public bool Contains(IEnumerable<RoleType> rts) {
			foreach (var rt in rts)
				if (Contains(rt))
					return true;
			return false;
		}
		/// <summary>
		/// 为当前对象添加权限
		/// </summary>
		/// <param name="rt"></param>
		/// <returns></returns>
		public void Add(RoleType rt) {
			RoleType |= rt;
		}
		/// <summary>
		/// 当前用户是否登录了
		/// </summary>
		public bool IsLogin {
			get {
				return GetRoleTypeList.Count != 0;
			}
		}

		/// <summary>
		/// 列表，当前所有权限
		/// </summary>
		public List<String> GetRoleTypeList {
			get {
				var lis =
					Enum.GetValues(typeof(RoleType));
				var list = new List<string>();
				foreach (object o in lis) {
					var r = (RoleType)o;
					if (Contains(r) && r != RoleType.Anonymous)
						list.Add(r.ToString());
				}
				return list;
			}
		}

	}
}
