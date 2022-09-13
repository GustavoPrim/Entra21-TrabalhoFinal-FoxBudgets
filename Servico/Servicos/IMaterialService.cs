using Repositorio.Entidades;

namespace Servico.Servicos
{
    public interface IMaterialService
    {
        bool Editar(MaterialEditarViewModel viewModel);
        bool Apagar(int id);
        Material Cadastrar(MaterialCadastrarViewModel viewModel);
        Material? ObterPorId(int id);
        IList<Material> ObterTodos();
    } 
}