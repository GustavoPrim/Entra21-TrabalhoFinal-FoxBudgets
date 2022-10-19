using FluentAssertions;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Orcamentos;
using Xunit;

namespace Tests.Servico.MapeamentoEntidades
{
    public class OrcamentoMaterialMapeamentoTests
    {
        private readonly IOrcamentoMapeamentoEntidade _orcamentoMapeamentoEntidade;
        public OrcamentoMaterialMapeamentoTests()
        {
            _orcamentoMapeamentoEntidade = new OrcamentoMapeamentoEntidade();
        }

        [Fact]
        public void Test_ConstruirCom()
        {
            //Arrange
            var viewModel = new OrcamentoCadastrarViewModel
            {
                Item = 0,
                Quantidade = 0
            };
            //Act
            var estoque = _orcamentoMapeamentoEntidade.ConstruirCom(viewModel);

            //Assert
            estoque.Item.Should().Be(viewModel.Item);
            estoque.Quantidade.Should().Be(viewModel.Quantidade);
        }

        [Fact]
        public void Test_AtualizarCom()
        {

        }
    }
}
