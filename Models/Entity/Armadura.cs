using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Armadura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public Armadura()
        {

        }
        public Armadura(string nome, int materialid)
        {
            this.Nome = nome;
            this.MaterialId = materialid;
        }
    }
}