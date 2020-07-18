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
    public class TipoArmasController : ApiController
    {
        [HttpGet]
        [Route("api/Raças/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new TipoArmaApplication().Listar());
        }

        [HttpGet]
        [Route("api/Raças/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new TipoArmaApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/Raças/salvar")]
        public IHttpActionResult Salvar(TipoArmaDto tipoarma)
        {
            return Ok(new TipoArmaApplication().Salvar(tipoarma));
        }

        [HttpPost]
        [Route("api/Raças/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new TipoArmaApplication().Remover(id));
        }
    }
}