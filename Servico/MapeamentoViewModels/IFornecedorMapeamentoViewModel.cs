using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoViewModels
{
    public interface IFornecedorMapeamentoViewModel
    {

         FornecedorEditarViewModel ConstruirCom(Fornecedor fornecedor);

        public FornecedorEditarViewModel ConstruirCom(Fornecedor fornecedor);
        
    }
}