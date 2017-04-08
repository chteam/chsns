namespace CHSNS
{
    using System;
    using System.Collections;
 
    using CHSNS.Interface;

    
    public class HttpCache : ICache
    {
        #region 新加属性

        ///<summary>
        /// 属性
        ///</summary>
        //protected Cache Cache
        //{
        //    get { return HttpContext.Current.Cache; }
        //}

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        public object this[string key]
        {
            get { return Get(key); }
        }

        /// <summary>
        /// 得到某一特定缓存
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public object Get(string key)
        {
            throw new NotImplementedException();
            //return Cache[key];
        }

        /// <summary>
        /// 得到某一特定缓存，并转为特定类型
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            throw new NotImplementedException(); //return Cache[key] as T;
        }

        /// <summary>
        /// 缓存中是否包含某一键值
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            throw new NotImplementedException();// return Cache[key] != null;
        }

        /// <summary>
        /// 将对象添加到缓存中
        /// </summary>
        /// <param name="key">为对象对应的键值</param>
        /// <param name="obj">对象</param>
        public void Add(string key, object obj)
        {
            throw new NotImplementedException();
            //Cache.Add(key, obj, null, DateTime.MaxValue
            //          , new TimeSpan(1, 0, 0),
            //          CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 将对象添加到缓存中
        /// </summary>
        /// <param name="key">为对象对应的键值</param>
        /// <param name="obj">对象</param>
        /// <param name="ts">过期时间</param>
        public void Add(string key, object obj, TimeSpan ts)
        {
            //Cache.Add(key, obj, null, DateTime.MaxValue
            //          , ts,
            //          CacheItemPriority.Normal, null);
            throw new NotImplementedException();
        }

        #endregion

        private TimeSpan? _timespan;

        #region 移除缓存

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public void RemoveAll()
        {
            //foreach (DictionaryEntry de in Cache)
            //{
            //    Cache.Remove(de.Key.ToString());
            //}
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        public void Remove(string key)
        {
            //Cache.Remove(key);
            throw new NotImplementedException();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置缓存的存储时间,默认值为1天
        /// </summary>
        public TimeSpan Timespan
        {
            get
            {
                if (_timespan == null)
                {
                    return new TimeSpan(1, 0, 0, 0, 0);
                }
                return _timespan.Value;
            }
            set { _timespan = value; }
        }

        #endregion
    }
}