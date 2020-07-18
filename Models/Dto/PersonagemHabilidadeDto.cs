using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class PersonagemHabilidadeDto
    {
        public int? Id { get; set; }
        public int PersonagemId { get; set; }
        public int HabilidadeId { get; set; }

        public PersonagemHabilidadeDto()
        {
        }
        public PersonagemHabilidadeDto(int id, int personagemId, int habilidadeId)
        {
            this.Id = id;
            this.PersonagemId = personagemId;
            this.HabilidadeId = habilidadeId;
        }
    }
}