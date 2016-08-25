using RSVP.Domain.Model;
using System.Web.Http;
using RSVP.Domain;

namespace RSVP.Controllers
{
    public class CommentsController : ApiController
    {

        public void Post(Comment comment)
        {
            using (var db = new MyDataContext())
            {
                db.Entry(comment).State = comment.CommentId == 0 ?
                                                System.Data.Entity.EntityState.Added :
                                                System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int commentId)
        {
            using (var db = new MyDataContext())
            {
                var commentToDelete = db.Comments.Find(commentId);

                if (commentToDelete != null)
                {
                    db.Entry(commentToDelete).State = System.Data.Entity.EntityState.Deleted;
                }

                db.SaveChanges();
            }
        }

    }
}
