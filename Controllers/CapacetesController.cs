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
    public class CapacetesController : ApiController
    {
        [HttpGet]
        [Route("api/Capacetes/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new CapaceteApplication().Listar());
        }

        [HttpGet]
        [Route("api/Capacetes/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new CapaceteApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/Capacetes/salvar")]
        public IHttpActionResult Salvar(CapaceteDto capacete)
        {
            return Ok(new CapaceteApplication().Salvar(capacete));
        }

        [HttpPost]
        [Route("api/Capacetes/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new CapaceteApplication().Remover(id));
        }
    }
}