using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.Servicos
{
    public interface IMaterialService
    {
        bool Editar(MateriasEditarViewModel viewModel);
        bool Apagar(int id);
        Material Cadastrar(MateriaisCadastrarViewModel viewModel);
        Material? ObterPorId(int id);
        IList<Material> ObterTodos();
    } 
}