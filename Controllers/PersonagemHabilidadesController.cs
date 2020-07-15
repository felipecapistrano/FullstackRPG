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
    public class PersonagemHabilidadesController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/PersonagemHabilidades
        public IQueryable<PersonagemHabilidadeDto> GetPersonagemHabilidades()
        {
            var personagemhabilidades = from x in db.PersonagemHabilidades
                            select new PersonagemHabilidadeDto()
                            {
                                Id = x.Id,
                                Personagem = x.Personagem.Nome,
                                Habilidade = x.Habilidade.Nome
                            };
            return personagemhabilidades;
        }

        // GET: api/PersonagemHabilidades/5
        [ResponseType(typeof(PersonagemHabilidade))]
        public IHttpActionResult GetPersonagemHabilidade(int id)
        {
            PersonagemHabilidade personagemHabilidade = db.PersonagemHabilidades.Find(id);
            if (personagemHabilidade == null)
            {
                return NotFound();
            }

            return Ok(personagemHabilidade);
        }

        // PUT: api/PersonagemHabilidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonagemHabilidade(int id, PersonagemHabilidade personagemHabilidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personagemHabilidade.Id)
            {
                return BadRequest();
            }

            db.Entry(personagemHabilidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagemHabilidadeExists(id))
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

        // POST: api/PersonagemHabilidades
        [ResponseType(typeof(PersonagemHabilidade))]
        public IHttpActionResult PostPersonagemHabilidade(PersonagemHabilidade personagemHabilidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonagemHabilidades.Add(personagemHabilidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personagemHabilidade.Id }, personagemHabilidade);
        }

        // DELETE: api/PersonagemHabilidades/5
        [ResponseType(typeof(PersonagemHabilidade))]
        public IHttpActionResult DeletePersonagemHabilidade(int id)
        {
            PersonagemHabilidade personagemHabilidade = db.PersonagemHabilidades.Find(id);
            if (personagemHabilidade == null)
            {
                return NotFound();
            }

            db.PersonagemHabilidades.Remove(personagemHabilidade);
            db.SaveChanges();

            return Ok(personagemHabilidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonagemHabilidadeExists(int id)
        {
            return db.PersonagemHabilidades.Count(e => e.Id == id) > 0;
        }
    }
}