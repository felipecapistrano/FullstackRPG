using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    [Table("Personagens")]
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int RaçaId { get; set; }
        public int? ArmaId { get; set; }
        public int? CapaceteId { get; set; }
        public int? ArmaduraId { get; set; }
        public int? PersonagemPaiId { get; set; }

        public virtual Raça Raça { get; set; }
        public virtual Arma Arma { get; set; }
        public virtual Capacete Capacete { get; set; }
        public virtual Armadura Armadura { get; set; }
        public virtual Personagem PersonagemPai { get; set; }
    }
}