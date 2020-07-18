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
    public class MateriaisController : ApiController
    {
        [HttpGet]
        [Route("api/Materiais/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new MaterialApplication().Listar());
        }

        [HttpGet]
        [Route("api/Materiais/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new MaterialApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/Materiais/salvar")]
        public IHttpActionResult Salvar(MaterialDto material)
        {
            return Ok(new MaterialApplication().Salvar(material));
        }

        [HttpPost]
        [Route("api/Materiais/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new MaterialApplication().Remover(id));
        }
    }
}