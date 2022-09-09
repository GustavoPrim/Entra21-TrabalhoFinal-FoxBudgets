using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.Servicos;
using Servico.ViewModels.Fornecedores;

namespace Servico
{
    public class FornecedorServico : IFornecedorServico
    {
        private readonly IFornecedorReposistorio _fornecedorRepositorio;
        private readonly IFornecedorMapeamentoEntidade _mapeamento;

        public FornecedorServico(
            IFornecedorReposistorio fornecedorRepositorio,
            IFornecedorMapeamentoEntidade mapeamentoEntidade)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _mapeamento = mapeamentoEntidade;
        }

        public void Apagar(int id) =>
            _fornecedorRepositorio.Apagar(id);

        public void Cadastrar(FornecedorCadastrarViewModel viewModel)
        {
            var fornecedor = _mapeamento.ConstruirCom(viewModel);
        }

        public void Editar(FornecedorCadastrarViewModel fornecedorEditarViewModel)
        {
            throw new NotImplementedException();
        }

        public Fornecedor ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Fornecedor> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
