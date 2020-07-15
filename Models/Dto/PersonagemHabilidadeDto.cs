using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class PersonagemHabilidadeDto
    {
        public int Id { get; set; }
        public string Personagem { get; set; }
        public string Habilidade { get; set; }
    }
}