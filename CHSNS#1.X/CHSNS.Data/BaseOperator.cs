
using System.Configuration;
using CHSNS.Models;

namespace CHSNS.Operator {
    public class BaseOperator {//} : IOperator {
        public CHSNSDBDataContext DBExtInstance {
            get {
                var db = new CHSNSDBDataContext(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    ) { DeferredLoadingEnabled = false };
                return db;
            }
        }
    }
}
