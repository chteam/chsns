namespace CHSNS.Models.Abstractions {
    public interface IGroupUser {
        long UserID { get; set; }

        long GroupID { get; set; }

        System.DateTime AddTime { get; set; }

        long PostCount { get; set; }

        byte Status { get; set; }
    }
}