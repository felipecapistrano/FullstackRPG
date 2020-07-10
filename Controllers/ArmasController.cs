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
using FullstackRPG.Models;

namespace FullstackRPG.Controllers
{
    public class ArmasController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Armas
        public IQueryable<Arma> GetArmas()
        {
            return db.Armas;
        }

        // GET: api/Armas/5
        [ResponseType(typeof(Arma))]
        public IHttpActionResult GetArma(int id)
        {
            Arma arma = db.Armas.Find(id);
            if (arma == null)
            {
                return NotFound();
            }

            return Ok(arma);
        }

        // PUT: api/Armas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArma(int id, Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arma.Id)
            {
                return BadRequest();
            }

            db.Entry(arma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
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

        // POST: api/Armas
        [ResponseType(typeof(Arma))]
        public IHttpActionResult PostArma(Arma arma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Armas.Add(arma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = arma.Id }, arma);
        }

        // DELETE: api/Armas/5
        [ResponseType(typeof(Arma))]
        public IHttpActionResult DeleteArma(int id)
        {
            Arma arma = db.Armas.Find(id);
            if (arma == null)
            {
                return NotFound();
            }

            db.Armas.Remove(arma);
            db.SaveChanges();

            return Ok(arma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaExists(int id)
        {
            return db.Armas.Count(e => e.Id == id) > 0;
        }
    }
}