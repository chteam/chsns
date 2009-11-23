
using System.Configuration;

namespace CHSNS.SQLServerImplement
{
    public class BaseOperator //: BaseSqlMapDao
    {//} : IOperator {
        internal CHSNSDBDataContext DBExtInstance {
            get {
                var db = new CHSNSDBDataContext(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    ) { DeferredLoadingEnabled = false };
                return db;
            }
        }
    }
}