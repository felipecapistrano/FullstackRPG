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
    public class ArmadurasController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Armaduras
        public IQueryable<ArmaduraDto> GetArmaduras()
        {
            var armaduras = from x in db.Armaduras
                        select new ArmaduraDto()
                        {
                            Id = x.Id,
                            Nome = x.Nome,
                            Material = x.Material.Nome
                        };
            return armaduras;
        }

        // GET: api/Armaduras/5
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult GetArmadura(int id)
        {
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return NotFound();
            }

            return Ok(armadura);
        }

        // PUT: api/Armaduras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArmadura(int id, Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != armadura.Id)
            {
                return BadRequest();
            }

            db.Entry(armadura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaduraExists(id))
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

        // POST: api/Armaduras
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult PostArmadura(Armadura armadura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Armaduras.Add(armadura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = armadura.Id }, armadura);
        }

        // DELETE: api/Armaduras/5
        [ResponseType(typeof(Armadura))]
        public IHttpActionResult DeleteArmadura(int id)
        {
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return NotFound();
            }

            db.Armaduras.Remove(armadura);
            db.SaveChanges();

            return Ok(armadura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmaduraExists(int id)
        {
            return db.Armaduras.Count(e => e.Id == id) > 0;
        }
    }
}