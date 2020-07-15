using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class PersonagemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raça { get; set; }
        public string Arma { get; set; }
        public string Capacete { get; set; }
        public string Armadura { get; set; }
        public int? PersonagemPai { get; set; }
    }
}