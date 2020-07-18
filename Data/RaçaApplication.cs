using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class RaçaApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<RaçaDto> Listar()
        {
            try
            {
                return db.Raça
                    .Select(x => new RaçaDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<RaçaDto> Buscar(int id)
        {
            try
            {
                return db.Raça
                    .Where(x => x.Id == id)
                    .Select(x => new RaçaDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
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
                db.Raça
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(RaçaDto raça)
        {
            try
            {
                if (raça.Id.HasValue)
                {
                    Editar(raça);
                    return raça.Id.Value;
                }
                else
                    return Cadastrar(new Raça(raça.Nome));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(RaçaDto raça)
        {
            db.Raça
                .Where(x => x.Id == raça.Id.Value)
                .Update(x => new Raça
                {
                    Nome = raça.Nome,
                });
        }
        public int Cadastrar(Raça raça)
        {
            db.Raça.Add(raça);
            db.SaveChanges();
            return raça.Id;
        }
    }
}