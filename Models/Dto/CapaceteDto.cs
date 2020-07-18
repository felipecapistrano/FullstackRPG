using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models.Dto
{
    public class CapaceteDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int MaterialId { get; set; }

        public CapaceteDto()
        {
        }
        public CapaceteDto(int id, string nome, int materialId)
        {
            this.Id = id;
            this.Nome = nome;
            this.MaterialId = materialId;
        }

        public CapaceteDto(string nome, int materialId)
        {
            this.Nome = nome;
            this.MaterialId = materialId;
        }

    }
}