using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.Servicos
{
    public interface IMaterialService
    {
        bool EditarMateriais(MateriaisEditarViewModel viewModel);
        bool Apagar(int id);
        Material CadastrarMateriais(MateriaisCadastrarViewModel viewModel);
        Material? ObterPorId(int id);
        IList<Material> ObterTodos();
    } 
}