using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class HabilidadeApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<HabilidadeDto> Listar()
        {
            try
            {
                return db.Habilidades
                    .Select(x => new HabilidadeDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Descricao = x.Descricao,
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<HabilidadeDto> Buscar(int id)
        {
            try
            {
                return db.Habilidades
                    .Where(x => x.Id == id)
                    .Select(x => new HabilidadeDto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Descricao = x.Descricao,
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
                db.Habilidades
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(HabilidadeDto habilidade)
        {
            try
            {
                if (habilidade.Id.HasValue)
                {
                    Editar(habilidade);
                    return habilidade.Id.Value;
                }
                else
                    return Cadastrar(new Habilidade(habilidade.Nome, habilidade.Descricao));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(HabilidadeDto habilidade)
        {
            db.Habilidades
                .Where(x => x.Id == habilidade.Id.Value)
                .Update(x => new Habilidade
                {
                    Nome = habilidade.Nome,
                    Descricao = habilidade.Descricao
                });
        }
        public int Cadastrar(Habilidade habilidade)
        {
            db.Habilidades.Add(habilidade);
            db.SaveChanges();
            return habilidade.Id;
        }
    }
}