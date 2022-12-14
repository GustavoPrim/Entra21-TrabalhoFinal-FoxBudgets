using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Materiais;

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

        public Material Cadastrar(MateriaisCadastrarViewModel viewModel)
        {
            var material = _materialMapeamento.ConstruirCom(viewModel);

            _materialRepositorio.CadastrarMateriais(material);
            return material;
        }

        public bool Editar(MateriaisEditarViewModel viewModel)
        {
            var material = _materialRepositorio.ObterPorId(viewModel.Id);

            if (material == null)
                return false;

            _materialMapeamento.AtualizarCom(material, viewModel);
            _materialRepositorio.EditarMateriais(material);
            return true;
        }

        public Material? ObterPorId(int id) =>
            _materialRepositorio.ObterPorId(id);

        public IList<Material> ObterTodos() =>
            _materialRepositorio.ObterTodos();

        public IList<SelectViewModel> ObterTodosSelect2()
        {
            var pets = _materialRepositorio.ObterTodos();

            var selectViewModels = pets
                .Select(x => new SelectViewModel
                {
                    Id = x.Id,
                    Text = x.Nome
                })
                .ToList();

            return selectViewModels;
        }
    }
}