using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FullstackRPG.Data;
using FullstackRPG.Models;

namespace FullstackRPG.Controllers
{
    public class ArmasController : ApiController
    {

        [HttpGet]
        [Route("api/armas/listar")]
        public IHttpActionResult Listar()
        {
            return Ok(new ArmaApplication().Listar());
        }

        [HttpPost]
        [Route("api/armas/salvar")]
        public IHttpActionResult Salvar(ArmaDto arma)
        {
            return Ok(new ArmaApplication().Salvar(arma));
        }

        [HttpPost]
        [Route("api/armas/remover")]
        public IHttpActionResult Remover(int id)
        {
            return Ok(new ArmaApplication().Remover(id));
        }
    }
}