
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.ViewModel {
    public class UserIndexViewModel : BaseViewModel{
        public UserIndexViewModel(bool? exists) {
            _exists = exists;
        }
        public UserIndexViewModel() { }
        public long OwnerId { get; set; }

        public long ViewerId { get; set; }
        bool? _exists;
        public bool Exists {
            get {
                if (_exists == null) {
                    if (OwnerId < 999) return false;
                    if (Profile == null) return false;
                    return Profile.ShowLevel <= 150;
                }
                return _exists.Value;
            }
        }
        public Profile Profile { get; set; }
        public BasicInformation Basic { get; set; }
        public int Relation { get; set; }
        public bool IsMe { get { return OwnerId == ViewerId; } }
        public bool IsOnline { get; set; }
    }
}
