﻿using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.MapeamentoViewModels
{
    public class OrcamentoMapeamentoViewModel : IOrcamentoMapeamentoViewModel
    {
        public OrcamentoEditarViewModel ConstruirCom(Orcamento orcamento)
        {
            return new OrcamentoEditarViewModel
            {
                Id = orcamento.Id
            };
        }
    }
}