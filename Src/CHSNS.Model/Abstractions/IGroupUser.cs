namespace CHSNS.Abstractions {
    public interface IGroupUser {
        long UserId { get; set; }

        long GroupId { get; set; }

        System.DateTime AddTime { get; set; }

        long PostCount { get; set; }

        byte Status { get; set; }
    }
}