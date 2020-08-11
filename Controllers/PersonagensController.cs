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

namespace FullstackRPG.Controllers
{
    public class PersonagensController : ApiController
    {

        [HttpGet]
        [Route("api/personagens/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new PersonagemApplication().Listar());
        }

        [HttpGet]
        [Route("api/personagens/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new PersonagemApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/personagens/salvar")]
        public IHttpActionResult Salvar(PersonagemDto arma)
        {
            return Ok(new PersonagemApplication().Salvar(arma));
        }

        [HttpPost]
        [Route("api/personagens/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new PersonagemApplication().Remover(id));
        }
    }
}