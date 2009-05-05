
using System.Configuration;
using CHSNS.SQLServerImplement;

namespace CHSNS.Operator {
     public class BaseOperator {//} : IOperator {
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
