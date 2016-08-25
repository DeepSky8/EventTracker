using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSVP.Domain.Model
{
    public class Event
    {

        public int EventId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDay { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }

        [InverseProperty("Event")]
        public virtual ICollection<Comment> Comments { get; set; }
    }

}