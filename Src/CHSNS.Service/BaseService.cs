using CHSNS.DataContext;

namespace CHSNS.Service
{
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