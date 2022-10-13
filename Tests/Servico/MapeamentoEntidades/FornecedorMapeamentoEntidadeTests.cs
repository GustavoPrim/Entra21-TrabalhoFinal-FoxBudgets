//using FluentAssertions;
//using Repositorio.Entidades;
//using Repositorio.Repositorios;
//using Servico.MapeamentoEntidades;
//using Servico.ViewModels.Fornecedores;
//using Xunit;

//namespace Tests.Servico.MapeamentoEntidades
//{
//    public class FornecedorMapeamentoEntidadeTests
//    {
//        private readonly IFornecedorMapeamentoEntidade _fornecedorMapeamentoEntidade;

//        public FornecedorMapeamentoEntidadeTests()
//        {
//            _fornecedorMapeamentoEntidade = new FornecedorMapeamentoEntidade();
//        }

//        [Fact]
//        public void Test_construirCom()
//        {
//            //Arrange
//            var fornecedor = new FornecedorCadastrarViewModel()
//            {
//                Nome = "guilherme",
//                Cnpj = "12.345.678/0001-90",
//                Categoria = 1,
//                DataFundacao = Convert.ToDateTime("2002/02/02"),
//                Email = "guilhermeDev@gmail.com",
//                Endereco = "rua careca",
//                Telefone = "99211-1529",
//                Login = "guizin",
//                Senha = "1111".GerarHash()
//            };
//            //Act
//            var fornecedores = _fornecedorMapeamentoEntidade.ConstruirCom(fornecedor);

//            //Assert
//            fornecedores.Nome.Should().Be(fornecedor.Nome);
//            fornecedores.Cnpj.Should().Be(fornecedor.Cnpj);
//            fornecedores.Categoria.Should().Be(fornecedor.Categoria);
//            fornecedores.DataFundacao.Should().Be(fornecedor.DataFundacao);
//            fornecedores.Email.Should().Be(fornecedor.Email);
//            fornecedores.Endereco.Should().Be(fornecedor.Endereco);
//            fornecedores.Telefone.Should().Be(fornecedor.Telefone);
//            fornecedores.Login.Should().Be(fornecedor.Login);
//            fornecedores.Senha.Should().Be(fornecedor.Senha.GerarHash());
//        }

//        [Fact]
//        public void Test_AtualizarCom()
//        {
//            //Arrange
//            var fornecedor = new Fornecedor
//            {
//                Id = 1,
//                Nome = "Cafe",
//                Cnpj = "12.345.678/0004-10",
//                Categoria = 1,
//                DataFundacao = Convert.ToDateTime("1990/10/01"),
//                Email = "cafe@gmail.com",
//                Endereco = "Thomi Souzina",
//                Telefone = "99211-1529",
//                Login = "queroCafe",
//                Senha = "1231".GerarHash()
//            };
//            var fornecedorEditar = new FornecedorEditarViewModel
//            {
//                Id = 1,
//                Nome = "cafe 2",
//                Cnpj = "12.345.678/0004-10",
//                Categoria = 2,
//                DataFundacao = Convert.ToDateTime("2011/02/01"),
//                Email = "queroCafe@gmail.com",
//                Endereco = "rua cafeina",
//                Telefone = "99980-1573",
//                Login = "queroCafe2",
//                Senha = "cafe".GerarHash(),
//            };
//            //Act
//            _fornecedorMapeamentoEntidade.AtualizarCampos(fornecedor, fornecedorEditar);

//            //Assert
//            fornecedor.Id.Should().Be(fornecedorEditar.Id);
//            fornecedor.Nome.Should().Be(fornecedorEditar.Nome);
//            fornecedor.Cnpj.Should().Be(fornecedorEditar.Cnpj);
//            fornecedor.Categoria.Should().Be(fornecedorEditar.Categoria);
//            fornecedor.DataFundacao.Should().Be(fornecedorEditar.DataFundacao);
//            fornecedor.Email.Should().Be(fornecedorEditar.Email);
//            fornecedor.Endereco.Should().Be(fornecedorEditar.Endereco);
//            fornecedor.Telefone.Should().Be(fornecedorEditar.Telefone);
//            fornecedor.Login.Should().Be(fornecedorEditar.Login);
//            fornecedor.Senha.Should().Be(fornecedorEditar.Senha);
//        }
//    }
//}
