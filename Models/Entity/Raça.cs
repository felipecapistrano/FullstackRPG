using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Raça
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Raça()
        {

        }
        public Raça(string nome)
        {
            this.Nome = nome;
        }
    }
}