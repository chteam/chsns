namespace CHSNS.Abstractions {
    public interface IAlbum {
        long ID { get; set; }

        string Name { get; set; }

        string Location { get; set; }

        string Description { get; set; }

        System.DateTime AddTime { get; set; }

        string FaceUrl { get; set; }

        int Count { get; set; }

        long UserID { get; set; }

        int Order { get; set; }

        byte ShowLevel { get; set; }
    }
}