using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class PersonagemDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int RaçaId { get; set; }
        public int? ArmaId { get; set; }
        public int? CapaceteId { get; set; }
        public int? ArmaduraId { get; set; }
        public int? PersonagemPaiId { get; set; }

        public PersonagemDto()
        {
        }
        public PersonagemDto(int id, string nome, int raçaid, int armaid, int capaceteid, int armaduraid, int personagempaiid)
        {
            this.Id = id;
            this.Nome = nome;
            this.RaçaId = raçaid;
            this.ArmaId = armaid;
            this.CapaceteId = capaceteid;
            this.ArmaduraId = armaduraid;
            this.PersonagemPaiId = personagempaiid;
        }

        public PersonagemDto(string nome, int raçaid, int armaid, int capaceteid, int armaduraid, int personagempaiid)
        {
            this.Nome = nome;
            this.RaçaId = raçaid;
            this.ArmaId = armaid;
            this.CapaceteId = capaceteid;
            this.ArmaduraId = armaduraid;
            this.PersonagemPaiId = personagempaiid;
        }
    }
}