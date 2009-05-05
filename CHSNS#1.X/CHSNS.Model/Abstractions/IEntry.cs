namespace CHSNS.Abstractions{
    public interface IEntry{
         long Id{get;set;}

         string Title{get;set;}

         long CreaterId{get;set;}

         System.DateTime UpdateTime{get;set;}

         long? CurrentId{get;set;}

         int EditCount{get;set;}

         long ViewCount{get;set;}

         int Status{get;set;}

         string Ext{get;set;}
    }
}