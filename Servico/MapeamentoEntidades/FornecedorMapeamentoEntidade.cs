using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoEntidades
{
	public class FornecedorMapeamentoEntidade : IFornecedorMapeamentoEntidade
    {
        public void AtualizarCampos(Fornecedor fornecedor, FornecedorEditarViewModel viewModel, string caminho)
        {
            fornecedor.Nome = viewModel.Nome;
            fornecedor.Cnpj = viewModel.Cnpj;
            fornecedor.Endereco = viewModel.Endereco;
            fornecedor.DataFundacao = viewModel.DataFundacao;
            fornecedor.Email = viewModel.Email;
            fornecedor.Telefone = viewModel.Telefone;
            fornecedor.Categoria = (int)viewModel.Categoria;
            fornecedor.Login = viewModel.Login;
            fornecedor.Senha = viewModel.Senha;

            if (!string.IsNullOrEmpty(caminho))
                fornecedor.CaminhoArquivo = caminho;
        }
        public Fornecedor ConstruirCom(FornecedorCadastrarViewModel viewModel, string caminho)
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
                Login = viewModel.Login,
                Senha = viewModel.Senha.GerarHash(),
                CaminhoArquivo = caminho,
            };
        }
    }
}