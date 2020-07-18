using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class HabilidadeDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public HabilidadeDto()
        {
        }
        public HabilidadeDto(int id, string nome, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public HabilidadeDto(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}