using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Estoque;

namespace Servico.Servicos
{
    public class EstoqueServico : IEstoqueServico
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IEstoqueMapeamentoEntidade _mapeamentoEntidade;

        public EstoqueServico(
            IEstoqueRepositorio estoqueRepositorio,
            IEstoqueMapeamentoEntidade mapeamentoEntidade)
        {
            _estoqueRepositorio = estoqueRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }
        public bool Apagar(int id) =>
            _estoqueRepositorio.Apagar(id);
        public Estoque CadastrarValor(EstoqueCadastrarViewModel viewModel)
        {
            var valor = _mapeamentoEntidade.ConstruirCom(viewModel);

            _estoqueRepositorio.CadastrarValor(valor);
            return valor;
        }
        public Estoque CadastrarQuantidade(EstoqueCadastrarViewModel viewModel)
        {
            var quantidade = _mapeamentoEntidade.ConstruirCom(viewModel);

            _estoqueRepositorio.CadastrarQuantidade(quantidade);
            return quantidade;
        }
        public bool Editar(EstoqueEditarViewModel viewModel)
        {
            var estoque = _estoqueRepositorio.ObterPorId(viewModel.Id);

            if (estoque == null)
                return false;
            _mapeamentoEntidade.AtualizarCom(estoque, viewModel);
            _estoqueRepositorio.Editar(estoque);
            return true;
        }
        public Estoque? ObterPorId(int id) =>
            _estoqueRepositorio.ObterPorId(id);
        public IList<Estoque> ObterTodos() =>
            _estoqueRepositorio.ObterTodos();
    }
}
