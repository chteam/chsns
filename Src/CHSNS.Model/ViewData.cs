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
    public partial class ViewData{
    
        public virtual long Id{get;set;}
    
        public virtual long OwnerId{get;set;}
    
        public virtual long ViewerId{get;set;}
    
        public virtual string IPandComputer{get;set;}
    
        public virtual string ViewPageUrl{get;set;}
    
        public virtual string LastUrl{get;set;}
    
        public virtual System.DateTime ViewTime{get;set;}
    
        public virtual byte ViewClass{get;set;}
    }
}
