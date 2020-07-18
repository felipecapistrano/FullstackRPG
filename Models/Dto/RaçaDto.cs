using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class RaçaDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public RaçaDto()
        {
        }
        public RaçaDto(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public RaçaDto(string nome)
        {
            this.Nome = nome;
        }
    }
}