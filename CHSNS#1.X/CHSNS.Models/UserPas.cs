using CHSNS.Models.Abstractions;

namespace CHSNS.Model {
    public class UserPas {
        public UserPas(bool? _exists) {
            this._exists = _exists;
        }
        public UserPas() { }
        public long OwnerID { get; set; }

        public long ViewerID { get; set; }
        bool? _exists;
        public bool Exists {
            get {
                if (_exists == null) {
                    if (OwnerID < 999) return false;
                    if (Profile == null) return false;
                    return Profile.ShowLevel <= 150;
                }
                return _exists.Value;
            }
        }
        public IProfile Profile { get; set; }
        public IBasicInformation Basic { get; set; }
        public int Relation { get; set; }
        public bool IsMe { get { return OwnerID == ViewerID; } }
        public bool IsOnline { get; set; }
    }
}
