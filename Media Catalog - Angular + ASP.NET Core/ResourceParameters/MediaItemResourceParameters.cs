using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.ResourceParameters
{
    public class MediaItemResourceParameters
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string SearchQuery { get; set; }
    }
}
