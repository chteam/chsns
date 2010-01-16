namespace CHSNS.Abstractions {
    public interface IEntryVersion {

        long Id { get; set; }
        string Title { get; set; }
        string Reason { get; set; }

        System.DateTime AddTime { get; set; }

        string Description { get; set; }

        string Reference { get; set; }

        long UserId { get; set; }

        int Status { get; set; }

        long? EntryId { get; set; }

        string ParentText { get; set; }

        string Ext { get; set; }
    }
}