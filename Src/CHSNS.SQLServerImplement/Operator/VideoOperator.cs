using System;
using System.Linq;

using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Operator {
    public class VideoOperator : BaseOperator{
      
        #region ICURDOperator<SuperNote> 成员

        public void Create(SuperNote content) {
  
        }

        public void Update(SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(long uid,params long[] uids) {
           
        }

        public PagedList<SuperNote> List(long uid, int p, int ep){
     
        }

        #endregion
    }
}
