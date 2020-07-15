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
using FullstackRPG.Models.Dto;

namespace FullstackRPG.Controllers
{
    public class CapacetesController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Capacetes
        public IQueryable<CapaceteDto> GetCapacetes()
        {
            var capacetes = from x in db.Capacetes
                            select new CapaceteDto()
                            {
                                Id = x.Id,
                                Nome = x.Nome,
                                Material = x.Material.Nome
                            };
            return capacetes;
        }

        // GET: api/Capacetes/5
        [ResponseType(typeof(Capacete))]
        public IHttpActionResult GetCapacete(int id)
        {
            Capacete capacete = db.Capacetes.Find(id);
            if (capacete == null)
            {
                return NotFound();
            }

            return Ok(capacete);
        }

        // PUT: api/Capacetes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCapacete(int id, Capacete capacete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != capacete.Id)
            {
                return BadRequest();
            }

            db.Entry(capacete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapaceteExists(id))
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

        // POST: api/Capacetes
        [ResponseType(typeof(Capacete))]
        public IHttpActionResult PostCapacete(Capacete capacete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Capacetes.Add(capacete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = capacete.Id }, capacete);
        }

        // DELETE: api/Capacetes/5
        [ResponseType(typeof(Capacete))]
        public IHttpActionResult DeleteCapacete(int id)
        {
            Capacete capacete = db.Capacetes.Find(id);
            if (capacete == null)
            {
                return NotFound();
            }

            db.Capacetes.Remove(capacete);
            db.SaveChanges();

            return Ok(capacete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CapaceteExists(int id)
        {
            return db.Capacetes.Count(e => e.Id == id) > 0;
        }
    }
}