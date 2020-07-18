using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class MaterialDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public MaterialDto()
        {
        }
        public MaterialDto(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public MaterialDto(string nome)
        {
            this.Nome = nome;
        }
    }
}