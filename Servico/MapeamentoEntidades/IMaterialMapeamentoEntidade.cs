using Repositorio.Entidades;

namespace Servico.MapeamentoEntidades
{
    public interface IMaterialMapeamentoEntidade
    {
        Material ConstruirCom(MaterialCadastrarViewModel viewModel);
        void AtualizarCom(Material material, MaterialEditarViewModel viewModel);
    }
}