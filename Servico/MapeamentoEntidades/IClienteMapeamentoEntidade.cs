﻿using Repositorio.Entidades;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.MapeamentoEntidades
{
    public interface IClienteMapeamentoEntidade
    {
        Cliente ConstruirCom(ClienteCadastrarViewModel viewModel, string caminho);
    }
}