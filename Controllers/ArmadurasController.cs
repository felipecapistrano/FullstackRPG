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
    public class ArmadurasController : ApiController
    {
        [HttpGet]
        [Route("api/armaduras/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new ArmaduraApplication().Listar());
        }

        [HttpGet]
        [Route("api/armaduras/buscar")]
        public IHttpActionResult Buscar(int id)
        {
            return Ok(new ArmaduraApplication().Buscar(id));
        }

        [HttpPost]
        [Route("api/armaduras/salvar")]
        public IHttpActionResult Salvar(ArmaduraDto armadura)
        {
            return Ok(new ArmaduraApplication().Salvar(armadura));
        }

        [HttpPost]
        [Route("api/armaduras/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new ArmaduraApplication().Remover(id));
        }
    }
}