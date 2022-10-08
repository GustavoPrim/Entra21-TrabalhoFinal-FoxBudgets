using Servico.MapeamentoViewModels;
using Servico.ViewModels.Fornecedores;
using Xunit;

namespace Tests.Servico.MapeamentoViewModels
{
    public class FornecedorMapeamentoViewModelTests
    {
        private readonly IFornecedorMapeamentoViewModel _fornecedorMapeamentoViewModel;

        public FornecedorMapeamentoViewModelTests()
        {
            _fornecedorMapeamentoViewModel = new FornecedorMapeamentoViewModel();
        }

        [Fact]
        public void Test_ConstruirCom()
        {
            //Arrange
            var viewModel = new FornecedorCadastrarViewModel
            {
                Nome = "João",
                Cnpj = "11.111.111/1111-22"
            };
            //Act
            //Assert
        }
    }
}
