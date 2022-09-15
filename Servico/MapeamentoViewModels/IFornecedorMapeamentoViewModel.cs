using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoViewModels
{
    public interface IFornecedorMapeamentoViewModel
    {
        public FornecedorEditarViewModel ConstruirCom(Fornecedor fornecedor);
        
    }
}