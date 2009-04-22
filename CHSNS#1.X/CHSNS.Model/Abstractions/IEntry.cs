namespace CHSNS.Models.Abstractions{
    public interface IEntry{
         long ID{get;set;}

         string Title{get;set;}

         long CreaterID{get;set;}

         System.DateTime UpdateTime{get;set;}

         long? CurrentID{get;set;}

         int EditCount{get;set;}

         long ViewCount{get;set;}

         int Status{get;set;}

         string Ext{get;set;}
    }
}