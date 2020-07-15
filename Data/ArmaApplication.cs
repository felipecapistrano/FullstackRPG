using FullstackRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class ArmaApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<ArmaDto> Listar()
        {
            try
            {
                return db.Armas
                    .Select(x => new ArmaDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        TipoId = x.TipoId,
                    })
                    .ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }
        public int Remover(int id)
        {
            try
            {
                db.Armas
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }catch(Exception e)
            {
                throw e;
            }
        }
        public int Salvar(ArmaDto arma)
        {
            try
            {
                if (arma.Id.HasValue)
                {
                    Editar(arma);
                    return arma.Id.Value;
                }
                else
                    return Cadastrar(new Arma(arma.Nome, arma.TipoId));
            }catch(Exception e)
            {
                throw e;
            }
        }
        public void Editar(ArmaDto arma)
        {
            db.Armas
                .Where(x => x.Id == arma.Id.Value)
                .Update(x => new Arma
                {
                    Nome = arma.Nome,
                    TipoId = arma.TipoId
                });
        }
        public int Cadastrar(Arma arma)
        {
            db.Armas.Add(arma);
            db.SaveChanges();
            return arma.Id;
        }
    }
}