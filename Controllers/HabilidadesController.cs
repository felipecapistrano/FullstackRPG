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
    public class HabilidadesController : ApiController
    {
        [HttpGet]
        [Route("api/Habilidades/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new HabilidadeApplication().Listar());
        }

        [HttpGet]
        [Route("api/Habilidades/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new HabilidadeApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/Habilidades/salvar")]
        public IHttpActionResult Salvar(HabilidadeDto habilidade)
        {
            return Ok(new HabilidadeApplication().Salvar(habilidade));
        }

        [HttpPost]
        [Route("api/Habilidades/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new HabilidadeApplication().Remover(id));
        }
    }
}