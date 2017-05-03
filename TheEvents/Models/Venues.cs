using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheEvents.Models
{
    public class Venues
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }

        public ICollection<Events> Events { get; set; }

    }
}