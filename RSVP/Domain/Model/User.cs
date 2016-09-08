using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSVP.Domain.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string EmailAddress { get; set; }
        public string Password { get; set; }


    }
}