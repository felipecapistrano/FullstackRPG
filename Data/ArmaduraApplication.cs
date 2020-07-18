using FullstackRPG.Models;
using FullstackRPG.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace FullstackRPG.Data
{
    public class ArmaduraApplication
    {
        private FullstackRPGContext db = new FullstackRPGContext();

        public List<ArmaduraDto> Listar()
        {
            try
            {
                return db.Armaduras
                    .Select(x => new ArmaduraDto
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
        public List<ArmaduraDto> Buscar(int id)
        {
            try
            {
                return db.Armaduras
                    .Where(x => x.Id == id)
                    .Select(x => new ArmaduraDto
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
                db.Armaduras
                    .Where(x => x.Id == id)
                    .Delete();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Salvar(ArmaduraDto armadura)
        {
            try
            {
                if (armadura.Id.HasValue)
                {
                    Editar(armadura);
                    return armadura.Id.Value;
                }
                else
                    return Cadastrar(new Armadura(armadura.Nome, armadura.MaterialId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Editar(ArmaduraDto armadura)
        {
            db.Armaduras
                .Where(x => x.Id == armadura.Id.Value)
                .Update(x => new Armadura
                {
                    Nome = armadura.Nome,
                    MaterialId = armadura.MaterialId
                });
        }
        public int Cadastrar(Armadura armadura)
        {
            db.Armaduras.Add(armadura);
            db.SaveChanges();
            return armadura.Id;
        }
    }
}