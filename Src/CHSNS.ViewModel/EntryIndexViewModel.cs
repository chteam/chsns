
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.ViewModel {
    public class EntryIndexViewModel  {
        public Entry Entry { set; get; }
        public EntryVersion Version { get; set; }
        public EntryExt Ext { get; set; }
    }
}