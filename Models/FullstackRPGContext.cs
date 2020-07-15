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

        public DbSet<Arma> Armas { get; set; }

        public DbSet<Armadura> Armaduras { get; set; }

        public DbSet<Material> Materiais { get; set; }

        public DbSet<Capacete> Capacetes { get; set; }

        public DbSet<Habilidade> Habilidades { get; set; }

        public DbSet<Raça> Raça { get; set; }

        public DbSet<Personagem> Personagens { get; set; }

        public DbSet<PersonagemHabilidade> PersonagemHabilidades { get; set; }

        public DbSet<TipoArma> TipoArmas { get; set; }
    }
}
