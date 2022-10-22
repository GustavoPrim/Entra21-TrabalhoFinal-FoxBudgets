using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Orcamentos;

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

        public Estoque? ObterPorId(int id) =>
            _estoqueRepositorio.ObterPorId(id);

        public IList<Estoque> ObterTodos() =>
            _estoqueRepositorio.ObterTodos();

        public List<EstoqueItemIndexViewModel> ObterItensEstoqueAtual(int idUsuarioLogado)
        {
            var estoque = _estoqueRepositorio.ObterTodosPorFornecedorId(idUsuarioLogado);

            if (estoque == null)
                return new List<EstoqueItemIndexViewModel>();

            return estoque.Select(
                x => new EstoqueItemIndexViewModel
                {
                    Quantidade = x.Quantidade,
                    Material = x.Material.Nome,
                    Valor = x.Valor,
                    EstoqueMaterialId = x.MaterialId
                }).ToList();
        }
        public Estoque Estocar(EstoqueCadastrarViewModel viewModel, int fornecedorId)
        {
            var estoque = _estoqueRepositorio.ObterPorFornecedorId(fornecedorId, viewModel.Item);

            if(estoque == null)
                estoque = _mapeamentoEntidade.ConstruirCom(viewModel, fornecedorId);

            estoque.Quantidade += viewModel.Quantidade;
            estoque.Valor = viewModel.Valor;

            _estoqueRepositorio.CriarOuAtualizar(estoque);

            return estoque;
        }
    }
}
