﻿using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoEntidades
{
    public class FornecedorMapeamentoEntidade : IFornecedorMapeamentoEntidade
    {
        public void AtualizarCampos(Fornecedor fornecedor, FornecedorEditarViewModel viewModel)
        {
            fornecedor.Nome = viewModel.Nome;
            fornecedor.Cnpj = viewModel.Cnpj;
            fornecedor.Endereco = viewModel.Endereco;
            fornecedor.DataFundacao = viewModel.DataFundacao;
            fornecedor.Email = viewModel.Email;
            fornecedor.Telefone = viewModel.Telefone;
            fornecedor.Categoria = (int)viewModel.Categoria;
        }

        public Fornecedor ConstruirCom(FornecedorCadastrarViewModel viewModel)
        {
            return new Fornecedor
            {
                Nome = viewModel.Nome,
                Cnpj = viewModel.Cnpj,
                Endereco = viewModel.Endereco,
                DataFundacao = viewModel.DataFundacao,
                Email = viewModel.Email,
                Telefone = viewModel.Telefone,
                Categoria = (int)viewModel.Categoria,
            };
        }
    }
}