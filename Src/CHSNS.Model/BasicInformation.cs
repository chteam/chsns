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
    public partial class BasicInformation
    {
        #region Primitive Properties
    
        public virtual long UserId
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Email
        {
            get;
            set;
        }
    
        public virtual bool IsEmailTrue
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Sex
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> Birthday
        {
            get;
            set;
        }
    
        public virtual int ProvinceId
        {
            get;
            set;
        }
    
        public virtual long CityId
        {
            get;
            set;
        }
    
        public virtual byte ShowLevel
        {
            get;
            set;
        }

        #endregion
    }
}