using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.ModelPas
{
    public class EventIndexViewModel
    {
        public ViewListPas NewViews{ get; set; }
        public ViewListPas LastViews { get; set; }
        public PagedList<Models.Event> Events { get; set; }
        public EventPagePas Page { get; set; }
    }
}
