using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.Models
{
    public class MediaItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherID { get; set; }
        public Artist Artist { get; set; }
        public int ArtistID { get; set; }
        public Country Country { get; set; }
        public int CountryID { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
        public DateTime PublishingDate { get; set; }

    }
}
