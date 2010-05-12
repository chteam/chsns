using System.Diagnostics.CodeAnalysis;

namespace MvcHelper
{
    public class FlexGridFetchOptions
    {
        public int page { get; set; }

        public string qtype { get; set; }

        public string query { get; set; }

        public int rp { get; set; }

        public string sortname { get; set; }

        public string sortorder { get; set; }
    }
}