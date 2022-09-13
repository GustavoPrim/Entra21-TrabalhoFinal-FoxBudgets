using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;

namespace Servico.Servicos
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepositorio _materialRepositorio;
        private readonly IMaterialMapeamentoEntidade _materialMapeamento;

        public MaterialService(
            IMaterialRepositorio materialRepositorio,
            IMaterialMapeamentoEntidade mapeamentoEntidade)
        {
            _materialRepositorio = materialRepositorio;
            _materialMapeamento = mapeamentoEntidade;
        }

        public bool Apagar(int id) =>
            _materialRepositorio.Apagar(id);

        public Material Cadastrar(MaterialCadastrarViewModel viewModel)
        {
            var material = _materialMapeamento.ConstruirCom(viewModel);

            _materialRepositorio.Cadastrar(material);
            return material;
        }

        public bool Editar(MaterialEditarViewModel viewModel)
        {
            var material = _materialRepositorio.ObterPorId(viewModel.Id);

            if (material == null)
                return false;

            _materialMapeamento.AtualizarCom(material, viewModel);
            _materialRepositorio.Editar(material);
            return true;
        }

        public Material? ObterPorId(int id) =>
            _materialRepositorio.ObterPorId(id);

        public IList<Material> ObterTodos() =>
            _materialRepositorio.ObterTodos();
    }
}