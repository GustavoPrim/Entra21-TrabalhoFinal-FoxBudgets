using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.MapeamentoEntidades
{
    public class OrcamentoMapeamentoEntidade : IOrcamentoMapeamentoEntidade
    {
        public void AtualizarCom(OrcamentoMaterial orcamento, OrcamentoEditarViewModel viewModel)
        {
            orcamento.Item = viewModel.Item;
            orcamento.Quantidade = viewModel.Quantidade;
        }

        public OrcamentoMaterial ConstruirCom(OrcamentoCadastrarViewModel viewModel)
        {
            return new OrcamentoMaterial
            {
                Item = viewModel.Item,
                Quantidade = viewModel.Quantidade,
            };
        }
    }
}
