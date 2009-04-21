namespace CHSNS.Models.Abstractions {
    public interface IGroup {
        long ID { get; set; }

        string Name { get; set; }

        string LogoUrl { get; set; }

        System.DateTime AddTime { get; set; }

        string Summary { get; set; }

        long CreaterID { get; set; }

        long UserCount { get; set; }

        byte AdminCount { get; set; }

        long PostCount { get; set; }

        long ViewCount { get; set; }

        byte JoinLevel { get; set; }

        byte ShowLevel { get; set; }

        byte Status { get; set; }

        byte Type { get; set; }

        string Ext { get; set; }
    }
}