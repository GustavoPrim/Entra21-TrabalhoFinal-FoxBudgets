using Repositorio;
using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos.FornecedorServico
{
    internal class FornecedorServico : IFornecedorServico
    {
        private readonly IFornecedorReposistorio _fornecedorReposistorio;

        public FornecedorServico(IFornecedorReposistorio fornecedorReposistorio)
        {
            _fornecedorReposistorio = fornecedorReposistorio;
        }

        public void Apagar(int id)
        {
            _fornecedorReposistorio.Apagar(id);
        }

        public void Cadastrar(FornecedorCadastrarViewModel fornecedorCadastrarViewModel)
        {
            throw new NotImplementedException();
        }

        public void Editar(FornecedorCadastrarViewModel fornecedorEditarViewModel)
        {
            throw new NotImplementedException();
        }

        public Fornecedor ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
