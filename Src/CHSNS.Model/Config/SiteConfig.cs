
namespace CHSNS.Config {
    using System;
    using CHSNS;
    /// <summary>
    /// ��վ����
    /// </summary>
    [Serializable]
    public class SiteConfig {
        public SiteConfig() { }

        public BaseConfig BaseConfig { get; set; }
        public RegVisitConfig RegVisitConfig { get; set; }
        public Publish Publish { get; set; }
        public NoteConfig Note { get; set; }
        public EveryPageConfig EveryPage { get; set; }
        public ScoreConfig Score { get; set; }
        public UploadConfig Upload { get; set; }
 
        /// <summary>
        /// ���л�Ϊxml
        /// </summary>
        public void Save() {
            //const string fn = "Config";
            //ConfigSerializer.Instance.Save(this, fn);
        }
    }
}
