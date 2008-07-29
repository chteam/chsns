using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace CHSNS {
	/// <summary>
	/// 缓存辅助类
	/// </summary>
	public class CHCache {
		/// <summary>
		/// 得到某一特定缓存
		/// </summary>
		/// <param name="key">键值</param>
		/// <returns></returns>
		public static object Get(string key) {
			return HttpContext.Current.Cache[key];
		}
		/// <summary>
		/// 得到某一特定缓存，并转为特定类型
		/// </summary>
		/// <typeparam name="T">返回的类型</typeparam>
		/// <param name="key">键值</param>
		/// <returns></returns>
		public static T Get<T>(string key) where T : class {
			return HttpContext.Current.Cache[key] as T;
		}
		/// <summary>
		/// 缓存中是否包含某一键值
		/// </summary>
		/// <param name="key">键值</param>
		/// <returns></returns>
		public static bool Contains(string key) {
			return HttpContext.Current.Cache[key] != null;
		}
		/// <summary>
		/// 将对象添加到缓存中
		/// </summary>
		/// <param name="key">为对象对应的键值</param>
		/// <param name="obj">对象</param>
		public static void Add(string key, object obj) {
			HttpContext.Current.Cache.Add(key, obj, null, DateTime.MaxValue
					, new TimeSpan(1, 0, 0),
					CacheItemPriority.Normal, null);
		}
		/// <summary>
		/// 将对象添加到缓存中
		/// </summary>
		/// <param name="key">为对象对应的键值</param>
		/// <param name="obj">对象</param>
		/// <param name="ts">过期时间</param>
		public static void Add(string key, object obj, TimeSpan ts) {
			HttpContext.Current.Cache.Add(key, obj, null, DateTime.MaxValue
					, ts,
					CacheItemPriority.Normal, null);
		}
	}
}
