using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class ArmaDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }

        public ArmaDto()
        {
            this.Id = Id;
            this.Nome = Nome;
            this.TipoId = TipoId;
        }
        public ArmaDto(int Id, string Nome, int TipoId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.TipoId = TipoId;
        }

        public ArmaDto(string Nome, int TipoId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.TipoId = TipoId;
        }
    }
}