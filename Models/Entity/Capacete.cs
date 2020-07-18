using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Capacete
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public Capacete()
        {

        }
        public Capacete(string nome, int materialid)
        {
            this.Nome = nome;
            this.MaterialId = materialid;
        }
    }
}