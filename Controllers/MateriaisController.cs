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
    public class MateriaisController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Materiais
        public IQueryable<Material> GetMaterials()
        {
            return db.Materials;
        }

        // GET: api/Materiais/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetMaterial(int id)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/Materiais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterial(int id, Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.Id)
            {
                return BadRequest();
            }

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materiais
        [ResponseType(typeof(Material))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.Id }, material);
        }

        // DELETE: api/Materiais/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult DeleteMaterial(int id)
        {
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Materials.Remove(material);
            db.SaveChanges();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialExists(int id)
        {
            return db.Materials.Count(e => e.Id == id) > 0;
        }
    }
}