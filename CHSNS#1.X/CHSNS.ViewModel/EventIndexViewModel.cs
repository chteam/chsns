using CHSNS.Model;
using CHSNS.Abstractions;

namespace CHSNS.ViewModel
{
    public class EventIndexViewModel : BaseViewModel
    {
        public ViewListPas NewViews { get; set; }
        public ViewListPas LastViews { get; set; }
        public PagedList<IEvent> Events { get; set; }
        public EventPagePas Page { get; set; }
    }
}
