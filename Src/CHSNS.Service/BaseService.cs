namespace CHSNS.Service
{
    using CHSNS.Models;
    using System.Configuration;

    public abstract class BaseService<T>
    {
        public static readonly T Instance;
        static BaseService()
        {
            Instance = default(T);
        }
        internal DbEntities DBExtInstance
        {
            get
            {
                var db = new DbEntities(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    );
                return db;
            }
        }
    }
}
