﻿using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public interface IOrcamentoServico
    {
        Orcamento Solicitar(OrcamentoCadastrarViewModel viewModel);
        bool Editar(OrcamentoEditarViewModel viewModel);
        Orcamento ObterPorId(int id);
        IList<Orcamento> ObterTodos();
        bool Apagar(int id);
    }
}
