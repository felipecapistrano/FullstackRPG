using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class MaterialApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<MaterialDto> Listar()
        {
            try
            {
                return db.Materiais
                    .Select(x => new MaterialDto
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
        public List<MaterialDto> Buscar(int id)
        {
            try
            {
                return db.Materiais
                    .Where(x => x.Id == id)
                    .Select(x => new MaterialDto
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
                db.Materiais
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(MaterialDto material)
        {
            try
            {
                if (material.Id.HasValue)
                {
                    Editar(material);
                    return material.Id.Value;
                }
                else
                    return Cadastrar(new Material(material.Nome));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(MaterialDto material)
        {
            db.Materiais
                .Where(x => x.Id == material.Id.Value)
                .Update(x => new Material
                {
                    Nome = material.Nome,
                });
        }
        public int Cadastrar(Material material)
        {
            db.Materiais.Add(material);
            db.SaveChanges();
            return material.Id;
        }
    }
}