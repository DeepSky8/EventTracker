using RSVP.Domain;
using RSVP.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RSVP.Controllers
{
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {

        [Authorize]
        [Route("")]
        public List<Event> Get()
        {
            var db = new MyDataContext();

            var events = db.Events.ToList<Event>();

            return events;
        }

        [Authorize]
        [Route("")]
        public Event Get(int eventId)
        {
            var db = new MyDataContext();

            var oneEvent = db.Events.Find(eventId);

            return oneEvent;
        }

        [Authorize]
        [Route("")]
        public void Post(Event @event)
        {
            //Add logic to guard against titles being too long
            //if(@event.Title.Length > 22)
            //{
            //    throw new InvalidOperationException("Bad title length");
            //}
            using (var db = new MyDataContext())
            {
                db.Entry(@event).State = @event.EventId == 0 ?
                                                System.Data.Entity.EntityState.Added :
                                                System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        [Authorize]
        [Route("")]
        public void Delete(int eventId)
        {
            using (var db = new MyDataContext())
            {
                var eventToDelete = db.Events.Find(eventId);

                if (eventToDelete != null)
                {
                    db.Entry(eventToDelete).State = System.Data.Entity.EntityState.Deleted;
                }

                db.SaveChanges();
            }
        }



    }

    public class SaveResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }

    public class Attender
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupNumber { get; set; }
    }

    public class AttendenceList
    {
        public List<Attender> attendence = new List<Attender>();
    }

}