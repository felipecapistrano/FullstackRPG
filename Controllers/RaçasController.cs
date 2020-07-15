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
    public class RaçasController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Raças
        public IQueryable<RaçaDto> GetRaça()
        {
            var raças = from x in db.Raça
                            select new RaçaDto()
                            {
                                Id = x.Id,
                                Nome = x.Nome,
                            };
            return raças;
        }

        // GET: api/Raças/5
        [ResponseType(typeof(Raça))]
        public IHttpActionResult GetRaça(int id)
        {
            Raça raça = db.Raça.Find(id);
            if (raça == null)
            {
                return NotFound();
            }

            return Ok(raça);
        }

        // PUT: api/Raças/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRaça(int id, Raça raça)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raça.Id)
            {
                return BadRequest();
            }

            db.Entry(raça).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaçaExists(id))
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

        // POST: api/Raças
        [ResponseType(typeof(Raça))]
        public IHttpActionResult PostRaça(Raça raça)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Raça.Add(raça);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = raça.Id }, raça);
        }

        // DELETE: api/Raças/5
        [ResponseType(typeof(Raça))]
        public IHttpActionResult DeleteRaça(int id)
        {
            Raça raça = db.Raça.Find(id);
            if (raça == null)
            {
                return NotFound();
            }

            db.Raça.Remove(raça);
            db.SaveChanges();

            return Ok(raça);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RaçaExists(int id)
        {
            return db.Raça.Count(e => e.Id == id) > 0;
        }
    }
}