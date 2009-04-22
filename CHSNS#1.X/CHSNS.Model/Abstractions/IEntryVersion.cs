namespace CHSNS.Models.Abstractions {
    public interface IEntryVersion {

        long ID { get; set; }

        string Reason { get; set; }

        System.DateTime AddTime { get; set; }

        string Description { get; set; }

        string Reference { get; set; }

        long UserID { get; set; }

        int Status { get; set; }

        long? EntryID { get; set; }

        string ParentText { get; set; }

        string Ext { get; set; }
    }
}