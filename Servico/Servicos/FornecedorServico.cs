using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos
{
    public class FornecedorServico : IFornecedorServico
    {
        private readonly IFornecedorReposistorio _fornecedorReposistorio;
        private readonly IFornecedorMapeamentoEntidade _mapeamentoEntidade;

        public FornecedorServico(
            IFornecedorReposistorio fornecedorReposistorio,
            IFornecedorMapeamentoEntidade mapeamentoEntidade)
        {
            _fornecedorReposistorio = fornecedorReposistorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }

        public bool Apagar(int id) =>
            _fornecedorReposistorio.Apagar(id);

        public Fornecedor CadastrarFornecedor(FornecedorCadastrarViewModel viewModel)
        {
            var fornecedor = _mapeamentoEntidade.ConstruirCom(viewModel);

            _fornecedorReposistorio.Cadastrar(fornecedor);

            return fornecedor;
        }

        public bool Editar(FornecedorEditarViewModel viewModel)
        {
            var fornecedor = _fornecedorReposistorio.ObterPorId(viewModel.Id);

            if (fornecedor == null)
                return false;

            _mapeamentoEntidade.AtualizarCampos(fornecedor, viewModel);
            _fornecedorReposistorio.Editar(fornecedor);

            return true;
        }

        public Fornecedor? ObterPorId(int id) =>
            _fornecedorReposistorio.ObterPorId(id);

        public IList<Fornecedor> ObterTodos() =>
            _fornecedorReposistorio.ObterTodos();
    }
}