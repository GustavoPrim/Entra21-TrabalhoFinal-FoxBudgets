using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoViewModels
{
    public class FornecedorMapeamentoViewModel : IFornecedorMapeamentoViewModel
    {
        public FornecedorEditarViewModel ConstruirCom(Fornecedor fornecedor)
        {

            return new FornecedorEditarViewModel
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj,
                DataFundacao = fornecedor.DataFundacao,
                Endereco = fornecedor.Endereco,
                Email = fornecedor.Email,
                Telefone = fornecedor.Telefone,
                Categoria = fornecedor.Categoria,
                Login = fornecedor.Login,
                Senha = fornecedor.Senha,
            };
        }
    }
}