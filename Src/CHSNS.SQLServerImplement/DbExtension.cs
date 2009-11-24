using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.SQLServerImplement
{
    public static class DbExtension
    {
        public static void SubmitChanges(this DbEntities db)
        {
            db.SaveChanges();
        }
    }
}
