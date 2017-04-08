namespace CHSNS
{
    using System;
    using System.Collections;
 
    using CHSNS.Interface;

    
    public class HttpCache : ICache
    {
        #region �¼�����

        ///<summary>
        /// ����
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
        /// �õ�ĳһ�ض�����
        /// </summary>
        /// <param name="key">��ֵ</param>
        /// <returns></returns>
        public object Get(string key)
        {
            throw new NotImplementedException();
            //return Cache[key];
        }

        /// <summary>
        /// �õ�ĳһ�ض����棬��תΪ�ض�����
        /// </summary>
        /// <typeparam name="T">���ص�����</typeparam>
        /// <param name="key">��ֵ</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            throw new NotImplementedException(); //return Cache[key] as T;
        }

        /// <summary>
        /// �������Ƿ����ĳһ��ֵ
        /// </summary>
        /// <param name="key">��ֵ</param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            throw new NotImplementedException();// return Cache[key] != null;
        }

        /// <summary>
        /// ��������ӵ�������
        /// </summary>
        /// <param name="key">Ϊ�����Ӧ�ļ�ֵ</param>
        /// <param name="obj">����</param>
        public void Add(string key, object obj)
        {
            throw new NotImplementedException();
            //Cache.Add(key, obj, null, DateTime.MaxValue
            //          , new TimeSpan(1, 0, 0),
            //          CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// ��������ӵ�������
        /// </summary>
        /// <param name="key">Ϊ�����Ӧ�ļ�ֵ</param>
        /// <param name="obj">����</param>
        /// <param name="ts">����ʱ��</param>
        public void Add(string key, object obj, TimeSpan ts)
        {
            //Cache.Add(key, obj, null, DateTime.MaxValue
            //          , ts,
            //          CacheItemPriority.Normal, null);
            throw new NotImplementedException();
        }

        #endregion

        private TimeSpan? _timespan;

        #region �Ƴ�����

        /// <summary>
        /// ������л���
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

        #region ����

        /// <summary>
        /// ��ȡ�����û���Ĵ洢ʱ��,Ĭ��ֵΪ1��
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