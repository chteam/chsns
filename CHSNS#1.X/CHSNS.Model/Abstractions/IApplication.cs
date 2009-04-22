namespace CHSNS.Models.Abstractions {
    public interface IApplication {
        long ID { get; set; }

        string Controller { get; set; }

        string Action { get; set; }

        string ParamStr { get; set; }

        string ClassName { get; set; }

        string FullName { get; set; }

        string ShortName { get; set; }

        string Vision { get; set; }

        string Icon { get; set; }

        long? Authorid { get; set; }

        System.DateTime Addtime { get; set; }

        System.DateTime Edittime { get; set; }

        string Description { get; set; }

        bool IsSystem { get; set; }

        bool IsTrue { get; set; }

        string DescriptionUrl { get; set; }

        long UserCount { get; set; }
    }
}