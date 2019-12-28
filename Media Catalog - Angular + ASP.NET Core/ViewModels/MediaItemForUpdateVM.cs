using Media_Catalog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.ViewModels
{
    public class MediaItemForUpdateVM
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public int PublisherID { get; set; }
        public int ArtistID { get; set; }
        public int CountryID { get; set; }
        public int GenreID { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}
