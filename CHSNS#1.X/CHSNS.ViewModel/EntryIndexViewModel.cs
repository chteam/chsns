using CHSNS.Abstractions;
using CHSNS.Model;

namespace CHSNS.ViewModel {
    public class EntryIndexViewModel : BaseViewModel {
        public IEntry Entry { set; get; }
        public IEntryVersion Version { get; set; }
        public EntryExt Ext { get; set; }
    }
}