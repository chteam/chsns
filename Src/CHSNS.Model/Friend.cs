//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace CHSNS.Models
{
    public partial class Friend
    {
        #region Primitive Properties
    
        public virtual long Id
        {
            get;
            set;
        }
    
        public virtual long FromId
        {
            get;
            set;
        }
    
        public virtual long ToId
        {
            get;
            set;
        }
    
        public virtual bool IsTrue
        {
            get;
            set;
        }
    
        public virtual bool IsCommon
        {
            get;
            set;
        }
    
        public virtual Nullable<int> FriendType
        {
            get;
            set;
        }
    
        public virtual Nullable<int> FriendSummary
        {
            get;
            set;
        }

        #endregion
    }
}
