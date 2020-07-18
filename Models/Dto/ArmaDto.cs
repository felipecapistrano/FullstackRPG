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
        }
        public ArmaDto(int id, string nome, int tipoid)
        {
            this.Id = id;
            this.Nome = nome;
            this.TipoId = tipoid;
        }

        public ArmaDto(string nome, int tipoid)
        {
            this.Nome = nome;
            this.TipoId = tipoid;
        }
    }
}