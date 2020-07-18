using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    [Table("Materiais")]
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Material()
        {

        }
        public Material(string nome)
        {
            this.Nome = nome;
        }
    }
}