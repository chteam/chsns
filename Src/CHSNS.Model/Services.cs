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
    public partial class Services
    {
        #region Primitive Properties
    
        public virtual long Id
        {
            get;
            set;
        }
    
        public virtual string Body
        {
            get;
            set;
        }
    
        public virtual string Answer
        {
            get;
            set;
        }
    
        public virtual byte Status
        {
            get;
            set;
        }
    
        public virtual System.DateTime SendTime
        {
            get;
            set;
        }
    
        public virtual System.DateTime AnswerTime
        {
            get;
            set;
        }
    
        public virtual long UserId
        {
            get;
            set;
        }
    
        public virtual string Email
        {
            get;
            set;
        }

        #endregion
    }
}
