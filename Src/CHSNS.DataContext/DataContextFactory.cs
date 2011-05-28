
namespace CHSNS.DataContext
{
    public class DataContextFactory
    {
        public IDbEntities GetInMemoryEntities()
        {
            return new InMemoryEntities();
        }

        public IDbEntities GetSqlServerEntities()
        {
            return new SqlServerEntities();
        }
    }
}