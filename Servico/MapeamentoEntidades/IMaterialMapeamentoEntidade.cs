using Repositorio.Entidades;
using Servico.ViewModels.Materiais;

namespace Servico.MapeamentoEntidades
{
    public interface IMaterialMapeamentoEntidade
    {
        Material ConstruirCom(MateriaisCadastrarViewModel viewModel);
        void AtualizarCom(Material material, MateriaisEditarViewModel viewModel);
    }
}