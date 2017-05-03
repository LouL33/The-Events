using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheEvents.Models
{
    public class Events
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }

        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public Venues Venue { get; set; }
        
        
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genres Genres { get; set; }
        
    }
}