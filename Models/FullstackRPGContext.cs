using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class FullstackRPGContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FullstackRPGContext() : base("name=FullstackRPGContext")
        {
        }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Arma> Armas { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Armadura> Armaduras { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Material> Materiais { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Capacete> Capacetes { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Habilidade> Habilidades { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Raça> Raça { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.Personagem> Personagens { get; set; }

        public System.Data.Entity.DbSet<FullstackRPG.Models.PersonagemHabilidade> PersonagemHabilidades { get; set; }
    }
}
