using FluentAssertions;
using Repositorio.Entidades;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Estoque;
using Xunit;

namespace Tests.Servico.MapeamentoEntidades
{
    public class EstoqueMapeamentoEntidadeTests
    {
        private readonly IEstoqueMapeamentoEntidade _estoqueMapeamentoEntidade;

        public EstoqueMapeamentoEntidadeTests()
        {
            _estoqueMapeamentoEntidade = new EstoqueMapeamentoEntidade();
        }

        [Fact]
        public void Test_construirCom()
        {
            //Arrange
            var viewModel = new EstoqueCadastrarViewModel
            {
                Quantidade = 1,
                Valor = 10
            };
            //Act
            var estoque = _estoqueMapeamentoEntidade.ConstruirCom(viewModel);

            //Assertion
            estoque.Quantidade.Should().Be(viewModel.Quantidade);
            estoque.Valor.Should().Be(viewModel.Valor);
        }

        [Fact]
        public void Test_AtualizarCom()
        {
            //Arrange
            var estoque = new Estoque
            {
                Valor = 100,
                Quantidade = 20
            };

            var estoqueEditar = new EstoqueEditarViewModel
            {
                Valor = 150,
                Quantidade = 230,
            };
            //Act
            _estoqueMapeamentoEntidade.AtualizarCom(estoque, estoqueEditar);
            //Assert
        }
    }
}
