namespace CHSNS.Config
{
    using System;

    /// <summary>
    /// Õ¯’æ≈‰÷√
    /// </summary>
    [Serializable]
    public class SiteConfig
    {
        public SiteConfig() { }
        ISerializer ConfigSerializer { get; set; }
        public SiteConfig(ISerializer serializer)
        {
            ConfigSerializer = serializer;
        }

        public BaseConfig BaseConfig { get; set; }
        public RegVisitConfig RegVisitConfig { get; set; }
        public Publish Publish { get; set; }
        public NoteConfig Note { get; set; }

        /// <summary>
        /// Gets the current.
        /// </summary>
        public SiteConfig Current
        {
            get
            {
                return ConfigSerializer.Load<SiteConfig>("Config");
            }
        }
        /// <summary>
        /// –Ú¡–ªØŒ™xml
        /// </summary>
        public void Save()
        {
            string fn = "Config";
            ConfigSerializer.Save(this, fn);
        }
    }
}
