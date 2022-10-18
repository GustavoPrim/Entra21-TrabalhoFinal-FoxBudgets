//using FluentAssertions;
//using Servico.MapeamentoViewModels;
//using Servico.ViewModels.Fornecedores;
//using Xunit;

//namespace Tests.Servico.MapeamentoViewModels;

//public class FornecedorMapeamentoViewModelTests
//{
//    private readonly IFornecedorMapeamentoViewModel _fornecedorMapeamentoViewModel;

//    public FornecedorMapeamentoViewModelTests()
//    {
//        _fornecedorMapeamentoViewModel = new FornecedorMapeamentoViewModel();
//    }

//    [Fact]
//    public void Test_ConstruirCom()
//    {
//        //Arrange
//        var viewModel = new FornecedorCadastrarViewModel
//        {
//            Nome = "João",
//            Cnpj = "11.111.111/1111-22",
//            Categoria = 1,
//            DataFundacao = Convert.ToDateTime("2003/01/02"),
//            Email = "jose@gmail.com",
//            Endereco = "thome de souzinha",
//            Telefone = "99772-1079",
//            Login = "cvc",
//            Senha = "sempre"
//        };
//        //Act
//        var fornecedor = _fornecedorMapeamentoViewModel.ConstruirCom(viewModel);

//        //Assert
//        fornecedor.Nome.Should().Be(viewModel.Nome);
//        fornecedor.Cnpj.Should().Be(viewModel.Cnpj);
//        fornecedor.Categoria.Should().Be(viewModel.Categoria);
//        fornecedor.DataFundacao.Should().Be(viewModel.DataFundacao);
//        fornecedor.Email.Should().Be(viewModel.Email);
//        fornecedor.Endereco.Should().Be(viewModel.Endereco);
//        fornecedor.Telefone.Should().Be(viewModel.Telefone);
//        fornecedor.Login.Should().Be(viewModel.Login);
//        fornecedor.Senha.Should().Be(viewModel.Senha);
//    }
//}


        //[Fact]
        //public void Test_ConstruirCom()
        //{
        //    //Arrange
        //    var viewModel = new FornecedorCadastrarViewModel
        //    {
        //        Nome = "João",
        //        Cnpj = "11.111.111/1111-22",
        //        Categoria = 1,
        //        DataFundacao = Convert.ToDateTime("2003/01/02"),
        //        Email = "jose@gmail.com",
        //        Endereco = "thome de souzinha",
        //        Telefone = "99772-1079",
        //        Login = "cvc",
        //        Senha = "sempre"
        //    };
        //    //Act
        //    var fornecedor = _fornecedorMapeamentoViewModel.ConstruirCom(viewModel);

        //    //Assert
        //    fornecedor.Nome.Should().Be(viewModel.Nome);
        //    fornecedor.Cnpj.Should().Be(viewModel.Cnpj);
        //    fornecedor.Categoria.Should().Be(viewModel.Categoria);
        //    fornecedor.DataFundacao.Should().Be(viewModel.DataFundacao);
        //    fornecedor.Email.Should().Be(viewModel.Email);
        //    fornecedor.Endereco.Should().Be(viewModel.Endereco);
        //    fornecedor.Telefone.Should().Be(viewModel.Telefone);
        //    fornecedor.Login.Should().Be(viewModel.Login);
        //    fornecedor.Senha.Should().Be(viewModel.Senha);
        //}
//    }
//}

//        [Fact]
//        public void Test_ConstruirCom()
//        {
//            //Arrange
//            var viewModel = new FornecedorCadastrarViewModel
//            {
//                Nome = "João",
//                Cnpj = "11.111.111/1111-22",
//                Categoria = 1,
//                DataFundacao = Convert.ToDateTime("2003/01/02"),
//                Email = "jose@gmail.com",
//                Endereco = "thome de souzinha",
//                Telefone = "99772-1079",
//                Login = "cvc",
//                Senha = "sempre"
//            };
//            //Act
//            var fornecedor = _fornecedorMapeamentoViewModel.ConstruirCom(viewModel);

//            //Assert
//            fornecedor.Nome.Should().Be(viewModel.Nome);
//            fornecedor.Cnpj.Should().Be(viewModel.Cnpj);
//            fornecedor.Categoria.Should().Be(viewModel.Categoria);
//            fornecedor.DataFundacao.Should().Be(viewModel.DataFundacao);
//            fornecedor.Email.Should().Be(viewModel.Email);
//            fornecedor.Endereco.Should().Be(viewModel.Endereco);
//            fornecedor.Telefone.Should().Be(viewModel.Telefone);
//            fornecedor.Login.Should().Be(viewModel.Login);
//            fornecedor.Senha.Should().Be(viewModel.Senha);
//        }
//    }
//}
