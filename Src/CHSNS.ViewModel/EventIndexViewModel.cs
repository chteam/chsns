using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.ViewModel
{
    public class EventIndexViewModel : BaseViewModel
    {
        public ViewListPas NewViews { get; set; }
        public ViewListPas LastViews { get; set; }
        public PagedList<Event> Events { get; set; }
        public EventPagePas Page { get; set; }
    }
}
