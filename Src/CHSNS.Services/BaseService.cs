using CHSNS.DataContext;

namespace CHSNS.Service
{
    using System.Diagnostics;

    public abstract class BaseService
    {
  
        private DataContextFactory _dataContextFactory;
        public DataContextFactory DataContextFactory
        {
            get { return _dataContextFactory ?? (_dataContextFactory = new DataContextFactory()); }
        }

        internal IDbEntities DbInstance
        {
            get { return DataContextFactory.GetSqlServerEntities(); }
        }
    }
}