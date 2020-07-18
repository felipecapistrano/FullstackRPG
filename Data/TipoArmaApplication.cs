using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class TipoArmaApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<TipoArmaDto> Listar()
        {
            try
            {
                return db.TipoArmas
                    .Select(x => new TipoArmaDto
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
        public List<TipoArmaDto> Buscar(int id)
        {
            try
            {
                return db.TipoArmas
                    .Where(x => x.Id == id)
                    .Select(x => new TipoArmaDto
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
                db.TipoArmas
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(TipoArmaDto tipoarma)
        {
            try
            {
                if (tipoarma.Id.HasValue)
                {
                    Editar(tipoarma);
                    return tipoarma.Id.Value;
                }
                else
                    return Cadastrar(new TipoArma(tipoarma.Nome));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(TipoArmaDto tipoarma)
        {
            db.TipoArmas
                .Where(x => x.Id == tipoarma.Id.Value)
                .Update(x => new TipoArma
                {
                    Nome = tipoarma.Nome,
                });
        }
        public int Cadastrar(TipoArma tipoarma)
        {
            db.TipoArmas.Add(tipoarma);
            db.SaveChanges();
            return tipoarma.Id;
        }
    }
}