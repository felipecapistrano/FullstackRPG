using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int RaçaId { get; set; }
        public int? ArmaId { get; set; }
        public int? CapaceteId { get; set; }
        public int? ArmaduraId { get; set; }
        public int? PersonagemPai { get; set; }
    }
}