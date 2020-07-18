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
        public virtual Personagem Personagem { get; set; }
        public virtual Habilidade Habilidade { get; set; }

        public PersonagemHabilidade()
        {

        }
        public PersonagemHabilidade(int personagemId, int habilidadeId)
        {
            this.PersonagemId = personagemId;
            this.HabilidadeId = habilidadeId;
        }
    }
}