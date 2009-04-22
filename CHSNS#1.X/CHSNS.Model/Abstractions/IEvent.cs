namespace CHSNS.Models.Abstractions {
    public interface IEvent {
        long ID { get; set; }

        string TemplateName { get; set; }

        long OwnerID { get; set; }

        long? ViewerID { get; set; }

        System.DateTime AddTime { get; set; }

        int ShowLevel { get; set; }

        string Json { get; set; }
    }
}