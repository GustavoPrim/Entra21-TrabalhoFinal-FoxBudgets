﻿using Repositorio.Entidades;

namespace Servico.ViewModels.Orcamentos
{
    public class OrcamentoFornecedorViewModel
    {
        public Fornecedor Fornecedores { get; set; }
        public string Item { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}