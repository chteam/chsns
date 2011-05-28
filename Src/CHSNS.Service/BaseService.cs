using System;
using CHSNS.DataContext;

namespace CHSNS.Service
{
    public abstract class BaseService
    {
        private ServicesFactory _servicesFactory;
        public virtual ServicesFactory ServicesFactory
        {
            get { return _servicesFactory ?? (_servicesFactory = new ServicesFactory()); }
        }

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