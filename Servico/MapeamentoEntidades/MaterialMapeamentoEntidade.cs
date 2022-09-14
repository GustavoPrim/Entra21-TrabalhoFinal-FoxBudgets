using Repositorio.Entidades;

namespace Servico.MapeamentoEntidades
{
    internal class MaterialMapeamentoEntidade : IMaterialMapeamentoEntidade
    {
        public void AtualizarCom(Material material, MaterialEditarViewModel viewModel)
        {
            material.Nome = viewModel.Nome;
            material.Sku = viewModel.Sku;
            material.DataValidade = viewModel.DataValidade;
            material.Descricao = viewModel.Descricao;
        }

        public Material ConstruirCom(MaterialCadastrarViewModel viewModel)
        {
            return new Material
            {
                Nome = viewModel.Nome,
                Sku = viewModel.Sku,
                DataValidade = viewModel.DataValidade,
                Descricao = viewModel.Descricao
            };
        }
    }
}