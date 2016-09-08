using Microsoft.AspNet.Identity;
using RSVP.Domain;
using RSVP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RSVP.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        
        [AllowAnonymous]
        public void Get(User newUser)
        {
            using (var db = new MyDataContext())
            {
                db.Entry(newUser).State = newUser.UserId == 0 ?
                                                System.Data.Entity.EntityState.Added :
                                                System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //[Authorize]
        [AllowAnonymous]
        public int Post(User user)
        {
            var result = 0;

            using (var db = new MyDataContext())
            {
                try
                {
                    List<User> userMatches = db.Users.Where(x => x.EmailAddress == user.EmailAddress).ToList();
                    User validUser = userMatches.Single();

                    if (validUser.Password == user.Password)
                    {
                        result = validUser.UserId;
                    }

                }
                catch (Exception e)
                {

                    throw new ArgumentException("Username and Password do not match", e);
                }



                return result;
            }
        }

    }
}