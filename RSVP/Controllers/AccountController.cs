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




        //[Authorize]
        //[Route("")]
        //public void Post(Users newUser)
        //{
        //    using (var db = new MyDataContext())
        //    {
        //        db.Entry(newUser).State = newUser.UserId == 0 ?
        //                                        System.Data.Entity.EntityState.Added :
        //                                        System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}

        //[Authorize]
        //[Route("")]
        //public bool Post(int UserId, string UserName)
        //{
        //    var result = false;

        //    using (var db = new MyDataContext())
        //    {
        //        var user = db.Users.Find(UserId);

        //        if (UserId == user.UserId)
        //        {
        //            result = true;
        //        }

        //        return result;
        //    }
        //}








        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Users userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}