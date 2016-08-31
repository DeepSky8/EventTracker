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
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        
        [AllowAnonymous]
        [Route("Register")]
        public void Register(Users newUser)
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
        public bool LogIn(int UserId, string UserName)
        {
            var result = false;

            using (var db = new MyDataContext())
            {
                var user = db.Users.Find(UserId);

                if (UserId == user.UserId)
                {
                    result = true;
                }

                return result;
            }
        }








    }
}