using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public virtual TipoArma Tipo { get; set; }

        public Arma()
        {

        }
        public Arma(string nome, int tipoid)
        {
            this.Nome = nome;
            this.TipoId = tipoid;
        }
    }
}