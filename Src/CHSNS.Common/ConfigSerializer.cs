﻿namespace CHSNS
{
    using Interface;

    /// <summary>
    /// 配置文件序列化及反序列化
    /// </summary>
    public class ConfigSerializer : ISerializer
    {
        public static ISerializer Instance { get; private set; }
        public static void Register(ISerializer serializer) {
            Instance = serializer;
        }

        private const string Path = "{0}Config/{1}.xml";
        private readonly string _rootPath;
        public ConfigSerializer(string rootPath)
        {
            _rootPath = rootPath;
        }

        #region ISerializer Members

        /// <summary>
        /// 序列化到配置文件　
        /// </summary>
        /// <typeparam name="T">序列化此类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="key">键值</param>
        public void Save<T>(T obj, string key) where T : class
        {
            XmlSerializer.Save(obj, string.Format(Path, _rootPath, key));
            ClearCache(key);
        }

        /// <summary>
        /// Clears the Cache of Congig.
        /// </summary>
        /// <param name="key">The key.</param>
        public void ClearCache(string key)
        {
            CacheProvider.Instance.Remove(string.Format(Path, _rootPath, key).ToLower());
        }

        /// <summary>
        /// 从配置文件反序列化
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="isUseCache">是否使用缓存的值</param>
        /// <returns></returns>
        public T Load<T>(string key, bool isUseCache) where T : class
        {
            string fn = string.Format(Path, _rootPath, key).ToLower();
            if (isUseCache)
            {
                if (!CacheProvider.Instance.Contains(fn))
                    CacheProvider.Instance.Add(fn, XmlSerializer.Load<T>(fn));
                return CacheProvider.Instance.Get<T>(fn);
            }
            return XmlSerializer.Load<T>(fn);
        }

        /// <summary>
        /// 从配置文件反序列化
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T Load<T>(string key) where T : class
        {
            return Load<T>(key, true);
        }

        #endregion
    }
}