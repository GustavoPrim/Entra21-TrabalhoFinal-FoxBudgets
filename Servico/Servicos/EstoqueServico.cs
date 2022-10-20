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
        public bool Apagar(int id) =>
            _estoqueRepositorio.Apagar(id);
        public Estoque CadastrarValor(EstoqueCadastrarViewModel viewModel, int fornecedorId)
        {
            var valor = _mapeamentoEntidade.ConstruirCom(viewModel);

            _estoqueRepositorio.CadastrarValor(valor);
            return valor;
        }
        public Estoque CadastrarQuantidade(EstoqueCadastrarViewModel viewModel, int fornecedorId)
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
        public List<EstoqueItemIndexViewModel> ObterItensEstoqueAtual(int idUsuarioLogado)
        {
            var estoque = _estoqueRepositorio.ObterPorFornecedorId(idUsuarioLogado);

            if (estoque == null)
                return new List<EstoqueItemIndexViewModel>();

            return estoque.EstoqueMaterial.Select(
                x => new EstoqueItemIndexViewModel
                {
                    Quantidade = x.Quantidade,
                    Material = x.Material,
                    Valor = x.Valor,
                    EstoqueMaterialId = x.MaterialId
                }).ToList();
        }
        public Estoque Estocar(EstoqueCadastrarViewModel viewModel, int fornecedorId)
        {
            var estoque = _estoqueRepositorio.ObterPorFornecedorId(fornecedorId);

            if (estoque == null)
                estoque = new Estoque
                {
                    FornecedorId = fornecedorId,
                    EstoqueMaterial = new List<Estoque>()
                };

            var estoqueMaterial = _mapeamentoEntidade.ConstruirCom(viewModel);

            estoque.EstoqueMaterial.Add(estoqueMaterial);

            _estoqueRepositorio.CrirOuAtualizar(estoque);

            return estoque;
        }
    }
}
