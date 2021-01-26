using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PryUserBarrigaAA.Models;

namespace PryUserBarrigaAA.Controllers
{
    public class FormsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Forms
        [Authorize]
        public IQueryable<Form> GetForms()
        {
            return db.Forms;
        }

        // GET: api/Forms/5
        [Authorize]
        [ResponseType(typeof(Form))]
        public IHttpActionResult GetForm(int id)
        {
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return NotFound();
            }

            return Ok(form);
        }

        // PUT: api/Forms/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForm(int id, Form form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != form.PersonId)
            {
                return BadRequest();
            }

            db.Entry(form).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Forms
        [Authorize]
        [ResponseType(typeof(Form))]
        public IHttpActionResult PostForm(Form form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Forms.Add(form);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = form.PersonId }, form);
        }

        // DELETE: api/Forms/5
        [Authorize]
        [ResponseType(typeof(Form))]
        public IHttpActionResult DeleteForm(int id)
        {
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return NotFound();
            }

            db.Forms.Remove(form);
            db.SaveChanges();

            return Ok(form);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormExists(int id)
        {
            return db.Forms.Count(e => e.PersonId == id) > 0;
        }
    }
}