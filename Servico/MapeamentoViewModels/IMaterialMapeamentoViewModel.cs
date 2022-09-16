using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.MapeamentoViewModels
{
    public interface IMaterialMapeamentoViewModel
    {
        MateriaisEditarViewModel ConstruirCom(Material material);
    }
}