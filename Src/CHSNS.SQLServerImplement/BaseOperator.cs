﻿
using System.Configuration;
//using CHSNS.SQLServerImplement.Aef;

namespace CHSNS.SQLServerImplement
{
    public class BaseOperator //: BaseSqlMapDao
    {//} : IOperator {
        internal DbEntities DBExtInstance {
            get {
                var db = new DbEntities(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    ) ;
                return db;
            }
        }
    }
}