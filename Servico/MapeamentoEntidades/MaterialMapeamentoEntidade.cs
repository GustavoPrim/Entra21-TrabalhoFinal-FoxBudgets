using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.MapeamentoEntidades
{
    public class MaterialMapeamentoEntidade : IMaterialMapeamentoEntidade
    {
        public void AtualizarCom(Material material, MateriaisEditarViewModel viewModel)
        {
            material.Nome = viewModel.Nome;
            material.Sku = viewModel.Sku;
            material.DataValidade = viewModel.DataValidade.GetValueOrDefault();
            material.Descricao = viewModel.Descricao;
        }

        public Material ConstruirCom(MateriaisCadastrarViewModel viewModel)
        {
            return new Material
            {
                Nome = viewModel.Nome,
                Sku = viewModel.Sku,
                DataValidade = viewModel.DataValidade.GetValueOrDefault(),
                Descricao = viewModel.Descricao
            };
        }
    }
}