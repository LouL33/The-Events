using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheEvents.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Events> Events { get; set; }
    }
}