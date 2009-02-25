using System.Collections.Generic;


namespace CHSNS
{
	/// <summary>
	/// 配置文件序列化及反序列化
	/// </summary>
	public class ConfigSerializer : CHSNS.ISerializer
	{
        IContext Context { get; set; }
        public ConfigSerializer(IContext context) {
            Context = context;
        }
		private const string PATH = "/Config/{0}.xml";

		/// <summary>
		/// 序列化到配置文件　
		/// </summary>
		/// <typeparam name="T">序列化此类型</typeparam>
		/// <param name="obj">要序列化的对象</param>
		/// <param name="key">键值</param>
		public  void Save<T>(T obj, string key) where T : class
		{
			XmlSerializer.Save(obj, string.Format(PATH, key));
			ClearCache(key);
		}
		/// <summary>
		/// Clears the Cache of Congig.
		/// </summary>
		/// <param name="key">The key.</param>
        public void ClearCache(string key) { Context.Cache.Remove(string.Format(PATH, key).ToLower()); }

		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <typeparam name="T">反序列化的目标类型</typeparam>
		/// <param name="key">键</param>
		/// <param name="IsUseCache">是否使用缓存的值</param>
		/// <returns></returns>
		public  T Load<T>(string key, bool IsUseCache) where T : class
		{
			var fn = string.Format(PATH, key).ToLower();
			if (IsUseCache) {
                if (!Context.Cache.Contains(fn))
                    Context.Cache.Add(fn, XmlSerializer.Load<T>(fn));
                return Context.Cache.Get<T>(fn);
			}
			return XmlSerializer.Load<T>(fn);
		}
		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <typeparam name="T">反序列化的目标类型</typeparam>
		/// <param name="key">键</param>
		/// <returns></returns>
		public  T Load<T>(string key) where T : class
		{
			return Load<T>(key, true);
		}


	}
}