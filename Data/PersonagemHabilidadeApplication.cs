using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class PersonagemHabilidadeApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<PersonagemHabilidadeDto> Listar()
        {
            try
            {
                return db.PersonagemHabilidades
                    .Select(x => new PersonagemHabilidadeDto
                    {
                        Id = x.Id,
                        PersonagemId = x.PersonagemId,
                        HabilidadeId = x.HabilidadeId
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<PersonagemHabilidadeDto> BuscarPersonagem(int personagemId)
        {
            try
            {
                return db.PersonagemHabilidades
                    .Where(x => x.PersonagemId == personagemId)
                    .Select(x => new PersonagemHabilidadeDto
                    {
                        Id = x.Id,
                        PersonagemId = x.PersonagemId,
                        HabilidadeId = x.HabilidadeId
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<PersonagemHabilidadeDto> BuscarHabilidade(int habilidadeId)
        {
            try
            {
                return db.PersonagemHabilidades
                    .Where(x => x.HabilidadeId == habilidadeId)
                    .Select(x => new PersonagemHabilidadeDto
                    {
                        Id = x.Id,
                        PersonagemId = x.PersonagemId,
                        HabilidadeId = x.HabilidadeId
                    })
                    .ToList();
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
                db.PersonagemHabilidades
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(PersonagemHabilidadeDto personagemHabilidade)
        {
            try
            {
                if (personagemHabilidade.Id.HasValue)
                {
                    Editar(personagemHabilidade);
                    return personagemHabilidade.Id.Value;
                }
                else
                    return Cadastrar(new PersonagemHabilidade(personagemHabilidade.PersonagemId, personagemHabilidade.HabilidadeId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(PersonagemHabilidadeDto personagemHabilidade)
        {
            db.PersonagemHabilidades
                .Where(x => x.Id == personagemHabilidade.Id.Value)
                .Update(x => new PersonagemHabilidade
                {
                    PersonagemId = personagemHabilidade.PersonagemId,
                    HabilidadeId = personagemHabilidade.HabilidadeId
                });
        }
        public int Cadastrar(PersonagemHabilidade personagemHabilidade)
        {
            db.PersonagemHabilidades.Add(personagemHabilidade);
            db.SaveChanges();
            return personagemHabilidade.Id;
        }
    }
}