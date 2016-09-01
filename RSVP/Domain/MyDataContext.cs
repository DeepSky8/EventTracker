using RSVP.Domain;
using RSVP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace RSVP.Domain
{


    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("Data Source = localhost; Initial Catalog = RSVP; Integrated Security = True;")
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}