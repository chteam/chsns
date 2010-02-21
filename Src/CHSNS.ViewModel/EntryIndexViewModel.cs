
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.ViewModel {
    public class EntryIndexViewModel : BaseViewModel {
        public Entry Entry { set; get; }
        public EntryVersion Version { get; set; }
        public EntryExt Ext { get; set; }
    }
}