namespace CHSNS.Abstractions {
    public interface IPhoto {
        long ID { get; set; }

        string Name { get; set; }

        long? AlbumID { get; set; }

        long UserID { get; set; }

        System.DateTime AddTime { get; set; }

        long Order { get; set; }

        string Ext { get; set; }

        int Status { get; set; }
    }
}