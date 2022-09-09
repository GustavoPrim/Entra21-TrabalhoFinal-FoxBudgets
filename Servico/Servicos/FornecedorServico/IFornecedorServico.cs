using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos.FornecedorServico
{
    public interface IFornecedorServico
    {
        void Cadastrar(FornecedorCadastrarViewModel fornecedorCadastrarViewModel);
        void Editar(FornecedorCadastrarViewModel fornecedorEditarViewModel);
        void Apagar(int id);
        Fornecedor ObterPorId(int id);
    }
}
