using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class PersonagemHabilidade
    {
        public int Id { get; set; }
        public int PersonagemId { get; set; }
        public int HabilidadeId { get; set; }
    }
}