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
    public class PersonagensController : ApiController
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        // GET: api/Personagens
        public IQueryable<PersonagemDto> Getpersonagens()
        {
            var personagens = from x in db.Personagens
                        select new PersonagemDto()
                        {
                            Id = x.Id,
                            Nome = x.Nome,
                            Raça = x.Raça.Nome,
                            Arma = x.Arma.Nome,
                            Capacete = x.Capacete.Nome,
                            Armadura = x.Armadura.Nome,
                            PersonagemPai = x.PersonagemPaiId
                        };
            return personagens;
        }

        // GET: api/Personagens/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult GetPersonagem(int id)
        {
            Personagem personagem = db.Personagens.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            return Ok(personagem);
        }

        // PUT: api/Personagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonagem(int id, Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personagem.Id)
            {
                return BadRequest();
            }

            db.Entry(personagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagemExists(id))
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

        // POST: api/Personagens
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult PostPersonagem(Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personagens.Add(personagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personagem.Id }, personagem);
        }

        // DELETE: api/Personagens/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult DeletePersonagem(int id)
        {
            Personagem personagem = db.Personagens.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            db.Personagens.Remove(personagem);
            db.SaveChanges();

            return Ok(personagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonagemExists(int id)
        {
            return db.Personagens.Count(e => e.Id == id) > 0;
        }
    }
}