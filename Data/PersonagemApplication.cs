using FullstackRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class PersonagemApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<PersonagemDto> Listar()
        {
            try
            {
                return db.Personagens
                    .Select(x => new PersonagemDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        RaçaId = x.RaçaId,
                        ArmaId = x.ArmaId,
                        CapaceteId = x.CapaceteId,
                        ArmaduraId = x.ArmaduraId,
                        PersonagemPaiId = x.PersonagemPaiId
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public PersonagemDto Buscar(int id)
        {
            try
            {
                return db.Personagens
                    .Where(x => x.Id == id)
                    .Select(x => new PersonagemDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        RaçaId = x.RaçaId,
                        ArmaId = x.ArmaId,
                        CapaceteId = x.CapaceteId,
                        ArmaduraId = x.ArmaduraId,
                        PersonagemPaiId = x.PersonagemPaiId,
                    })
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Remover(int id)
        {
            try
            {
                db.Personagens
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(PersonagemDto personagem)
        {
            try
            {
                if (personagem.Id.HasValue)
                {
                    Editar(personagem);
                    return personagem.Id.Value;
                }
                else
                    return Cadastrar(new Personagem(personagem.Nome, personagem.RaçaId, personagem.ArmaId, personagem.CapaceteId, personagem.ArmaduraId, personagem.PersonagemPaiId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(PersonagemDto personagem)
        {
            db.Personagens
                .Where(x => x.Id == personagem.Id.Value)
                .Update(x => new Personagem
                {
                    Nome = personagem.Nome,
                    RaçaId = personagem.RaçaId,
                    ArmaId = personagem.ArmaId,
                    CapaceteId = personagem.CapaceteId,
                    ArmaduraId = personagem.ArmaduraId,
                    PersonagemPaiId = personagem.PersonagemPaiId
                });
        }
        public int Cadastrar(Personagem personagem)
        {
            db.Personagens.Add(personagem);
            db.SaveChanges();
            return personagem.Id;
        }
    }
}