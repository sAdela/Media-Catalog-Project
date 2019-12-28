using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.ViewModels
{
    public class MediaItemVM
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Artist { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}
