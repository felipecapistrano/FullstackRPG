using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class TipoArmaDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public TipoArmaDto()
        {
        }
        public TipoArmaDto(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public TipoArmaDto(string nome)
        {
            this.Nome = nome;
        }
    }
}