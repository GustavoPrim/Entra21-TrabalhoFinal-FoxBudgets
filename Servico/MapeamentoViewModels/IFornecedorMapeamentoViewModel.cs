using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoViewModels
{
    public interface IFornecedorMapeamentoViewModel
    {
         FornecedorCadastrarViewModel ConstruirCom(Fornecedor fornecedor);
    }
}