//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CHSNS.Models
{
    public partial class Reply
    {
        #region Primitive Properties
    
        public virtual long Id
        {
            get;
            set;
        }
    
        public virtual long UserId
        {
            get;
            set;
        }
    
        public virtual long SenderId
        {
            get;
            set;
        }
    
        public virtual string Body
        {
            get;
            set;
        }
    
        public virtual System.DateTime AddTime
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
    
        public virtual byte IsTellMe
        {
            get;
            set;
        }

        #endregion
    }
}
