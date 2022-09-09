using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoEntidades
{
    public interface IFornecedorMapeamentoEntidade
    {
        Fornecedor ConstruirCom(FornecedorCadastrarViewModel viewModel);
        void AtualizarCampos(Fornecedor fornecedor, FornecedorEditarViewModel viewModel);
    }
}