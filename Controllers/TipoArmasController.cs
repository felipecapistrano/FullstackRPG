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
    public class TipoArmasController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/TipoArmas
        public IQueryable<TipoArmaDto> GetTipoArmas()
        {
            var tipoarmas = from x in db.TipoArmas
                            select new TipoArmaDto()
                            {
                                Id = x.Id,
                                Nome = x.Nome,
                            };
            return tipoarmas;
        }

        // GET: api/TipoArmas/5
        [ResponseType(typeof(TipoArma))]
        public IHttpActionResult GetTipoArma(int id)
        {
            TipoArma tipoArma = db.TipoArmas.Find(id);
            if (tipoArma == null)
            {
                return NotFound();
            }

            return Ok(tipoArma);
        }

        // PUT: api/TipoArmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoArma(int id, TipoArma tipoArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoArma.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoArma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoArmaExists(id))
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

        // POST: api/TipoArmas
        [ResponseType(typeof(TipoArma))]
        public IHttpActionResult PostTipoArma(TipoArma tipoArma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoArmas.Add(tipoArma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoArma.Id }, tipoArma);
        }

        // DELETE: api/TipoArmas/5
        [ResponseType(typeof(TipoArma))]
        public IHttpActionResult DeleteTipoArma(int id)
        {
            TipoArma tipoArma = db.TipoArmas.Find(id);
            if (tipoArma == null)
            {
                return NotFound();
            }

            db.TipoArmas.Remove(tipoArma);
            db.SaveChanges();

            return Ok(tipoArma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoArmaExists(int id)
        {
            return db.TipoArmas.Count(e => e.Id == id) > 0;
        }
    }
}