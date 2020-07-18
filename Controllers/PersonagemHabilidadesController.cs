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
using FullstackRPG.Data;
using FullstackRPG.Models;
using FullstackRPG.Models.Dto;

namespace FullstackRPG.Controllers
{
    public class PersonagemHabilidadesController : ApiController
    {
        [HttpGet]
        [Route("api/PersonagemHabilidades/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new PersonagemHabilidadeApplication().Listar());
        }

        [HttpGet]
        [Route("api/PersonagemHabilidades/buscarpersonagem")]
        public IHttpActionResult BuscarPersonagem(int personagemId)
        {
            return Ok(new PersonagemHabilidadeApplication().BuscarPersonagem(personagemId));
        }

        [HttpGet]
        [Route("api/PersonagemHabilidades/buscarhabilidade")]
        public IHttpActionResult BuscarHabilidade(int habilidadeId)
        {
            return Ok(new PersonagemHabilidadeApplication().BuscarHabilidade(habilidadeId));
        }

        [HttpPost]
        [Route("api/PersonagemHabilidades/salvar")]
        public IHttpActionResult Salvar(PersonagemHabilidadeDto personagemhabilidade)
        {
            return Ok(new PersonagemHabilidadeApplication().Salvar(personagemhabilidade));
        }

        [HttpPost]
        [Route("api/PersonagemHabilidades/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new PersonagemHabilidadeApplication().Remover(id));
        }
    }
}