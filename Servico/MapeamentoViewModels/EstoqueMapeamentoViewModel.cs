using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoViewModels
{
    public class EstoqueMapeamentoViewModel : IEstoqueMapeamentoViewModel
    {
        public EstoqueEditarViewModel ConstruirCom(Estoque estoque)
        {
            return new EstoqueEditarViewModel
            {
                Id = estoque.Id,
                //Nome = estoque.Nome,
                Quantidade = estoque.Quantidade,
                //Valor = estoque.Valor
            };
        }
    }
}
