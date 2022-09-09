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
            IFornecedorMapeamentoEntidade mapeamento)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _mapeamento = mapeamento;
        }

        public bool Apagar(int id) =>
            _fornecedorRepositorio.Apagar(id);

        public Fornecedor Cadastrar(FornecedorCadastrarViewModel viewModel)
        {
            var fornecedor = _mapeamento.ConstruirCom(viewModel);
            _fornecedorRepositorio.Cadastrar(fornecedor);
            return fornecedor;
        }

        public bool Editar(FornecedorEditarViewModel viewModel)
        {
            var fornecedor = _fornecedorRepositorio.ObterPorId(viewModel.Id);

            if (fornecedor == null)
                return false;

            _mapeamento.AtualizarCampos(fornecedor, viewModel);
            _fornecedorRepositorio.Editar(fornecedor);
            return true;
        }

        public Fornecedor? ObterPorId(int id) =>
            _fornecedorRepositorio.ObterPorId(id);

        public IList<Fornecedor> ObterTodos() =>
            _fornecedorRepositorio.ObterTodos();
    }
}