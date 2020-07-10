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
    public class HabilidadesController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Habilidades
        public IQueryable<Habilidade> GetHabilidades()
        {
            return db.Habilidades;
        }

        // GET: api/Habilidades/5
        [ResponseType(typeof(Habilidade))]
        public IHttpActionResult GetHabilidade(int id)
        {
            Habilidade habilidade = db.Habilidades.Find(id);
            if (habilidade == null)
            {
                return NotFound();
            }

            return Ok(habilidade);
        }

        // PUT: api/Habilidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHabilidade(int id, Habilidade habilidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilidade.Id)
            {
                return BadRequest();
            }

            db.Entry(habilidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadeExists(id))
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

        // POST: api/Habilidades
        [ResponseType(typeof(Habilidade))]
        public IHttpActionResult PostHabilidade(Habilidade habilidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habilidades.Add(habilidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = habilidade.Id }, habilidade);
        }

        // DELETE: api/Habilidades/5
        [ResponseType(typeof(Habilidade))]
        public IHttpActionResult DeleteHabilidade(int id)
        {
            Habilidade habilidade = db.Habilidades.Find(id);
            if (habilidade == null)
            {
                return NotFound();
            }

            db.Habilidades.Remove(habilidade);
            db.SaveChanges();

            return Ok(habilidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilidadeExists(int id)
        {
            return db.Habilidades.Count(e => e.Id == id) > 0;
        }
    }
}