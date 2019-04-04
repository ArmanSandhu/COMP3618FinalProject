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
using IMDbDotNetDomain;
using IMDbDotNetInfrastructure;
using System.Web.Http.Cors;
using NLog;

namespace IMDbDotNetAPI.Controllers
{
    [EnableCors(origins:"http://localhost:1234", headers:"*", methods:"*")]
    public class titlebasicsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private UnitOfWork unitOfWork = new UnitOfWork(new IMDbEntities1());
        //public titlebasicsController()
        //: this(new EFGenericRepository<titlebasic>(new IMDbEntities1()))
        //{
        //}

        //public titlebasicsController(IRepository<titlebasic> inRepo)
        //{
        //    repo = inRepo;
        //}

        // GET: api/titlebasics
        public IHttpActionResult Gettitlebasics(int startindex = 0, int pagesize = 100)
        {
            var titlebasics = unitOfWork.Repository<titlebasic>().Reads(startindex, pagesize);
            if (titlebasics == null)
            {
                return NotFound();
            }
            logger.Trace("Get all title basics");
            return Ok(titlebasics);
        }

        // GET: api/titlebasics/5
        [ResponseType(typeof(titlebasic))]
        public IHttpActionResult Gettitlebasic(string id, int startindex=0, int pagesize=100)
        {
            var titlebasics = unitOfWork.Repository<titlebasic>().Reads(id, startindex, pagesize);
            if (titlebasics == null)
            {
                return NotFound();
            }
            logger.Trace("Get title basics containing " + id);
            return Ok(titlebasics);
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

            unitOfWork.Repository<titlebasic>().Update(titlebasic);

            try
            {
                unitOfWork.Repository<titlebasic>().SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                titlebasic check = unitOfWork.Repository<titlebasic>().Read(x => x.tconst == titlebasic.tconst);
                if (check == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            logger.Trace("Update " + id);
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

            unitOfWork.Repository<titlebasic>().Create(titlebasic);
            

            try
            {
                unitOfWork.Repository<titlebasic>().SaveChanges();
            }
            catch (DbUpdateException)
            {
                titlebasic check = unitOfWork.Repository<titlebasic>().Read(x => x.tconst == titlebasic.tconst);
                if (check != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            logger.Trace("Create " + titlebasic.tconst);
            return CreatedAtRoute("DefaultApi", new { id = titlebasic.tconst }, titlebasic);
        }

        // DELETE: api/titlebasics/5
        [ResponseType(typeof(titlebasic))]
        public IHttpActionResult Deletetitlebasic(string id)
        {
            titlebasic titlebasic = unitOfWork.Repository<titlebasic>().Read(x => x.tconst == id);
            if (titlebasic == null)
            {
                return NotFound();
            }

            unitOfWork.Repository<titlebasic>().Delete(titlebasic);
            unitOfWork.Repository<titlebasic>().SaveChanges();
            logger.Trace("Delete " + id);
            return Ok(titlebasic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool titlebasicExists(string id)
        //{
        //    return db.titlebasics.Count(e => e.tconst == id) > 0;
        //}
    }
}