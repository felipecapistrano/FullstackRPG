namespace FullstackRPG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FullstackRPG.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FullstackRPG.Models.FullstackRPGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FullstackRPG.Models.FullstackRPGContext context)
        {
            context.Armas.AddOrUpdate(x => x.Id,
                new Arma() { Id = 1, Nome = "Espada inicial", Tipo = "Espada"},
                new Arma() { Id = 2, Nome = "Machado de guerra", Tipo = "Machado"},
                new Arma() { Id = 3, Nome = "Excalibur", Tipo = "Espada" }
                );

            context.Materiais.AddOrUpdate(x => x.Id,
                new Material() { Id = 1, Nome = "Bronze" },
                new Material() { Id = 2, Nome = "Prata" },
                new Material() { Id = 3, Nome = "Ouro" },
                new Material() { Id = 4, Nome = "Pano"}
                );

            context.Capacetes.AddOrUpdate(x => x.Id,
                new Capacete() { Id = 1, Nome = "Capacete inicial", MaterialId = 1 },
                new Capacete() { Id = 2, Nome = "Elmo dourado", MaterialId = 3 },
                new Capacete() { Id = 3, Nome = "Bandana do herói", MaterialId = 4 }
                );

            context.Armaduras.AddOrUpdate(x => x.Id,
                new Armadura() { Id = 1, Nome = "Armadura inicial", MaterialId = 1 },
                new Armadura() { Id = 2, Nome = "Couraça de prata", MaterialId = 2 }
                );

            context.Habilidades.AddOrUpdate(x => x.Id,
                new Habilidade() { Id = 1, Nome = "Investida", Descricao = "Investe na direção do alvo e o derruba" },
                new Habilidade() { Id = 2, Nome = "Bola de fogo", Descricao = "Conjura uma esfera em chamas que incendeia aquilo que encosta" }
                );

            context.Raça.AddOrUpdate(x => x.Id,
                new Raça() { Id = 1, Nome = "Humano"},
                new Raça() { Id = 2, Nome = "Elfo"},
                new Raça() { Id = 2, Nome = "Orc" }
                );

            context.Personagens.AddOrUpdate(x => x.Id,
                new Personagem() { Id = 1, Nome = "Jubileu", RaçaId = 1, ArmaId = 1, CapaceteId = 1, ArmaduraId = 1 },
                new Personagem() { Id = 2, Nome = "Biluga", RaçaId = 1 },
                new Personagem() { Id = 3, Nome = "Joeslei", RaçaId = 3, ArmaId = 3 }
                );

            context.PersonagemHabilidades.AddOrUpdate(x => x.Id,
                new PersonagemHabilidade() { Id = 1, PersonagemId = 3, HabilidadeId = 2},
                new PersonagemHabilidade() { Id = 2, PersonagemId = 1, HabilidadeId = 1},
                new PersonagemHabilidade() { Id = 3, PersonagemId = 3, HabilidadeId = 1}
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
