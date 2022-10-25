using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoEntidades
{
    public class FornecedorMapeamentoEntidade : IFornecedorMapeamentoEntidade
    {
        public void AtualizarCampos(Fornecedor fornecedor, FornecedorEditarViewModel viewModel)
        {
            fornecedor.Nome = viewModel.Nome;
            fornecedor.Cnpj = viewModel.Cnpj;
            fornecedor.Cpf = viewModel.Cpf;
            fornecedor.Endereco = viewModel.Endereco;
            fornecedor.DataFundacao = viewModel.DataFundacao;
            fornecedor.Email = viewModel.Email;
            fornecedor.Telefone = viewModel.Telefone;
            fornecedor.Categoria = (int)viewModel.Categoria;
            fornecedor.Login = viewModel.Login;
            fornecedor.Senha = viewModel.Senha;
        }
        public Fornecedor ConstruirCom(FornecedorCadastrarViewModel viewModel)
        {
            return new Fornecedor
            {
                Nome = viewModel.Nome,
                Cnpj = viewModel.Cnpj,
                Cpf = viewModel.Cpf,
                Endereco = viewModel.Endereco,
                DataFundacao = viewModel.DataFundacao,
                Email = viewModel.Email,
                Telefone = viewModel.Telefone,
                Categoria = (int)viewModel.Categoria,
                Login = viewModel.Login,
                Senha = viewModel.Senha.GerarHash(),
            };
        }
    }
}