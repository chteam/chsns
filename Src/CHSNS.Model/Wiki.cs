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
    public partial class Wiki{
    
        public virtual long Id{get;set;}
    
        public virtual string Url{get;set;}
    
        public virtual long CreaterId{get;set;}
    
        public virtual System.DateTime UpdateTime{get;set;}
    
        public virtual long? CurrentId{get;set;}
    
        public virtual int EditCount{get;set;}
    
        public virtual long ViewCount{get;set;}
    
        public virtual int Status{get;set;}
    
        public virtual string Ext{get;set;}
    
        public virtual bool IsDisplayTitle{get;set;}
    }
}