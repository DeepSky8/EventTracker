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
        [Route("Register")]
        public void Register(User newUser)
        {
            using (var db = new MyDataContext())
            {
                db.Entry(newUser).State = newUser.UserId == 0 ?
                                                System.Data.Entity.EntityState.Added :
                                                System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        [Authorize]
        [Route("")]
        public bool UserLogin(string UserName, string Password)
        {
            var result = false;

            using (var db = new MyDataContext())
            {
                try
                {
                    var user = db.Users.Find(UserName);
                    if (user.UserName == UserName && user.Password == Password)
                    {
                        result = true;
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