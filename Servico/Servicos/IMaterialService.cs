using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Materiais;

namespace Servico.Servicos;

public interface IMaterialService
{
    bool Editar(MateriaisEditarViewModel viewModel);
    bool Apagar(int id);
    Material Cadastrar(MateriaisCadastrarViewModel viewModel);
    Material? ObterPorId(int id);
    IList<Material> ObterTodos();
    IList<SelectViewModel> ObterTodosSelect2();
}
