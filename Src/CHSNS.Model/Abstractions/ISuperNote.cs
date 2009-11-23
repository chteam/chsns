namespace CHSNS.Abstractions {
    public interface ISuperNote {
        long ID { get; set; }

        string Title { get; set; }

        string Faceurl { get; set; }

        string Url { get; set; }

        string Description { get; set; }

        long UserID { get; set; }

        long ViewCount { get; set; }

        System.DateTime AddTime { get; set; }

        byte ShowLevel { get; set; }

        long? SystemCategory { get; set; }

        long? Category { get; set; }

        byte Type { get; set; }
    }
}