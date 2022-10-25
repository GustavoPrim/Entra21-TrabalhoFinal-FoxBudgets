using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.MapeamentoViewModels
{
    public class MaterialMapeamentoViewModel : IMaterialMapeamentoViewModel
    {
        public MateriaisEditarViewModel ConstruirCom(Material material)
        {
            return new MateriaisEditarViewModel
            {
                Id = material.Id,
                DataValidade = material.DataValidade,
                Descricao = material.Descricao
            };
        }
    }
}