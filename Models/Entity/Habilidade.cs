﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace FullstackRPG.Models
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Habilidade()
        {

        }
        public Habilidade(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }

    }
}