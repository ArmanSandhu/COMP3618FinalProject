using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IMDbDotNetAPI.Models;

namespace IMDbDotNetAPI.Controllers
{
    public class titlebasicsController : ApiController
    {
        private IMDbEntities1 db = new IMDbEntities1();

        // GET: api/titlebasics
        public IQueryable<titlebasic> Gettitlebasics()
        {
            return db.titlebasics;
        }

        // GET: api/titlebasics/5
        [ResponseType(typeof(titlebasic))]
        public IHttpActionResult Gettitlebasic(string id)
        {
            titlebasic titlebasic = db.titlebasics.Find(id);
            if (titlebasic == null)
            {
                return NotFound();
            }

            return Ok(titlebasic);
        }

        // PUT: api/titlebasics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttitlebasic(string id, titlebasic titlebasic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != titlebasic.tconst)
            {
                return BadRequest();
            }

            db.Entry(titlebasic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!titlebasicExists(id))
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

        // POST: api/titlebasics
        [ResponseType(typeof(titlebasic))]
        public IHttpActionResult Posttitlebasic(titlebasic titlebasic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.titlebasics.Add(titlebasic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (titlebasicExists(titlebasic.tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = titlebasic.tconst }, titlebasic);
        }

        // DELETE: api/titlebasics/5
        [ResponseType(typeof(titlebasic))]
        public IHttpActionResult Deletetitlebasic(string id)
        {
            titlebasic titlebasic = db.titlebasics.Find(id);
            if (titlebasic == null)
            {
                return NotFound();
            }

            db.titlebasics.Remove(titlebasic);
            db.SaveChanges();

            return Ok(titlebasic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool titlebasicExists(string id)
        {
            return db.titlebasics.Count(e => e.tconst == id) > 0;
        }
    }
}