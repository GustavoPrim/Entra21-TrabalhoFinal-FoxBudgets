using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoViewModels
{
    public interface IEstoqueMapeamentoViewModel
    {
        EstoqueEditarViewModel ConstruirCom(Estoque estoque);
    }
}
