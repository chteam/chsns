
namespace CHSNS.Models
{
    using System;

    public class Application
    {
        public virtual long Id { get; set; }

        public virtual string Controller { get; set; }

        public virtual string Action { get; set; }

        public virtual string ParamStr { get; set; }

        public virtual string ClassName { get; set; }

        public virtual string FullName { get; set; }

        public virtual string ShortName { get; set; }

        public virtual string Vision { get; set; }

        public virtual string Icon { get; set; }

        public virtual long? Authorid { get; set; }

        public virtual DateTime Addtime { get; set; }

        public virtual DateTime Edittime { get; set; }

        public virtual string Description { get; set; }

        public virtual bool IsSystem { get; set; }

        public virtual bool IsTrue { get; set; }

        public virtual string DescriptionUrl { get; set; }

        public virtual long UserCount { get; set; }
    }
}