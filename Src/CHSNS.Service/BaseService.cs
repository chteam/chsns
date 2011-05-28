using CHSNS.DataContext;

namespace CHSNS.Service
{
    using CHSNS.Models;
    using System.Configuration;

    public abstract class BaseService<T>
    {
        #region Service Singlet

        public static T Instance { get; private set; }
        static BaseService()
        {
            Instance = (T)System.Activator.CreateInstance(typeof(T));
        }

        #endregion
        internal SqlServerEntities DbInstance
        {
            get
            {
                var db = new SqlServerEntities();
                return db;
            }
        }
    }
}
