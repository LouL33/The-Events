using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }

        public int VenuesId { get; set; }
        [ForeignKey("VenuesId")]
        public Venues Venue { get; set; }
        
        
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genres Genres { get; set; }
        
    }
}