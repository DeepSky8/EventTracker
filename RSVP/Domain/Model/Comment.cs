using Newtonsoft.Json;
using System;

namespace RSVP.Domain.Model
{
    public class Comment
    {
        public Comment() { }

        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int EventId { get; set; }

        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}