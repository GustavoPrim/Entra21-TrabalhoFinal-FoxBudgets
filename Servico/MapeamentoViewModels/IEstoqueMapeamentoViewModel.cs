using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoViewModels
{
    public interface IEstoqueMapeamentoViewModel
    {
        EstoqueEditarViewModel ConstruirCom(Estoque estoque)
        {
            return new EstoqueEditarViewModel
            {
                Id = estoque.Id,
                Nome = estoque.Nome,
                Quantidade = estoque.Quantidade,
                Valor = estoque.Valor
            };
        }
    }
}
