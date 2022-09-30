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
            var estoque = new EstoqueCadastrarViewModel
            {
                Nome = "estocao",
                Quantidade = 1,
                Valor = 10
            };
            //Act
            //Assertion
        }
    }
}
