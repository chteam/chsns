//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CHSNS.Models
{
    public partial class Comment
    {
        #region Primitive Properties
    
        public virtual long Id
        {
            get;
            set;
        }
    
        public virtual Nullable<long> ShowerId
        {
            get;
            set;
        }
    
        public virtual long OwnerId
        {
            get;
            set;
        }
    
        public virtual long SenderId
        {
            get;
            set;
        }
    
        public virtual System.DateTime AddTime
        {
            get;
            set;
        }
    
        public virtual string Body
        {
            get;
            set;
        }
    
        public virtual bool IsReply
        {
            get;
            set;
        }
    
        public virtual bool IsSee
        {
            get;
            set;
        }
    
        public virtual bool IsDel
        {
            get;
            set;
        }
    
        public virtual byte Type
        {
            get;
            set;
        }
    
        public virtual byte IsTellMe
        {
            get;
            set;
        }

        #endregion
    }
}
