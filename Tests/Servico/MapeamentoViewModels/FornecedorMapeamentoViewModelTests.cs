using Servico.MapeamentoViewModels;
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
        public void Test_construirCom_semEstoque()
        {

        }
    }
}
