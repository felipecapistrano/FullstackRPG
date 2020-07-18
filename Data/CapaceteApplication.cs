using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class CapaceteApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<CapaceteDto> Listar()
        {
            try
            {
                return db.Capacetes
                    .Select(x => new CapaceteDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        MaterialId = x.MaterialId,
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<CapaceteDto> Buscar(int id)
        {
            try
            {
                return db.Capacetes
                    .Where(x => x.Id == id)
                    .Select(x => new CapaceteDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        MaterialId = x.MaterialId,
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
                db.Capacetes
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(CapaceteDto capacete)
        {
            try
            {
                if (capacete.Id.HasValue)
                {
                    Editar(capacete);
                    return capacete.Id.Value;
                }
                else
                    return Cadastrar(new Capacete(capacete.Nome, capacete.MaterialId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(CapaceteDto capacete)
        {
            db.Capacetes
                .Where(x => x.Id == capacete.Id.Value)
                .Update(x => new Capacete
                {
                    Nome = capacete.Nome,
                    MaterialId = capacete.MaterialId
                });
        }
        public int Cadastrar(Capacete capacete)
        {
            db.Capacetes.Add(capacete);
            db.SaveChanges();
            return capacete.Id;
        }
    }
}