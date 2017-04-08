namespace CHSNS.Models
{
    public partial class Album{
    
        public virtual long Id{get;set;}
    
        public virtual string Name{get;set;}
    
        public virtual string Location{get;set;}
    
        public virtual string Description{get;set;}
    
        public virtual System.DateTime AddTime{get;set;}
    
        public virtual string FaceUrl{get;set;}
    
        public virtual int Count{get;set;}
    
        public virtual long UserId{get;set;}
    
        public virtual int Order{get;set;}
    
        public virtual byte ShowLevel{get;set;}
    }
}
