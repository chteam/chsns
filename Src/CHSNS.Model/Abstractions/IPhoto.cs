namespace CHSNS.Abstractions {
    public interface IPhoto {
        long Id { get; set; }

        string Title { get; set; }

        long? AlbumId { get; set; }

        long UserId { get; set; }

        System.DateTime AddTime { get; set; }

        string Url { get; set; }

        string Domain { get; set; }

        long Order { get; set; }

        string Summary { get; set; }

        int Status { get; set; }
    }
}