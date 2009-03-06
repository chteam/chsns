using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.ModelPas;

namespace CHSNS.ViewModel
{
    public class EventIndexViewModel : BaseViewModel
    {
        public ViewListPas NewViews { get; set; }
        public ViewListPas LastViews { get; set; }
        public PagedList<Models.Event> Events { get; set; }
        public EventPagePas Page { get; set; }
    }
}
