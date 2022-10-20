using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Fornecedores;
using Servico.ViewModels.Orcamentos;

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

        public Estoque Adicionar(EstoqueCadastrarViewModel viewModel, int fornecedorId)
        {
            var estoque = _fornecedorReposistorio.ObterPorFornecedorId(fornecedorId);

            if (estoque == null)
                estoque = new Estoque
                {
                    ClienteId = clienteId,
                    OrcamentoMateriais = new List<OrcamentoMaterial>()
                };

            var orcamentoMaterial = _mapeamentoEntidade.ConstruirCom(viewModel);

            estoque.OrcamentoMateriais.Add(orcamentoMaterial);

            _orcamentoRepositorio.CrirOuAtualizar(estoque);

            return estoque;
        }

        public bool Apagar(int id) =>
            _fornecedorReposistorio.Apagar(id);

        public Fornecedor BuscarPorLogin(string login, string senha)
        {
            var fornecedor = _fornecedorReposistorio.BuscarPorLogin(login, senha);

            return fornecedor;
        }

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

        public List<OrcamentoItemIndexViewModel> ObterItensOrcamentoAtual(int idUsuarioLogado)
        {
            throw new NotImplementedException();
        }

        public Fornecedor? ObterPorId(int id) =>
            _fornecedorReposistorio.ObterPorId(id);

        public IList<Fornecedor> ObterTodos() =>
            _fornecedorReposistorio.ObterTodos();
    }
}