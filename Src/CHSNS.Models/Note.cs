namespace CHSNS.Models
{
    public partial class Note{
    
        public virtual long Id{get;set;}
    
        public virtual string Title{get;set;}
    
        public virtual string Summary{get;set;}
    
        public virtual string Body{get;set;}
    
        public virtual System.DateTime AddTime{get;set;}
    
        public virtual System.DateTime EditTime{get;set;}
    
        public virtual byte Type{get;set;}
    
        public virtual long ParentId{get;set;}
    
        public virtual long UserId{get;set;}
    
        public virtual string Username{get;set;}
    
        public virtual byte IsTellMe{get;set;}
    
        public virtual bool IsAnonymous{get;set;}
    
        public virtual byte ShowLevel{get;set;}
    
        public virtual long ViewCount{get;set;}
    
        public virtual long PushCount{get;set;}
    
        public virtual long TrackBackCount{get;set;}
    
        public virtual long CommentCount{get;set;}
    
        public virtual long LastCommentUserId{get;set;}
    
        public virtual string LastCommentUsername{get;set;}
    
        public virtual System.DateTime LastCommentTime{get;set;}
    
        public virtual string Ext{get;set;}
    }
}
