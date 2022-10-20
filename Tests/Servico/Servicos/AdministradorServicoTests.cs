using FluentAssertions;
using NSubstitute;
using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.Servicos;
using Servico.ViewModels.Administradores;
using Xunit;

namespace Tests.Servico.Servicos
{
    public class AdministradorServicoTests
    {
        private readonly IAdministradorServico _administradorServico;
        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IAdministradorMapeamentoEntidade _administradorMapeamentoEntidade;
        private readonly OrcamentoContexto _contexto;


        public AdministradorServicoTests()
        {
            _administradorRepositorio = Substitute.For<IAdministradorRepositorio>();

            _administradorMapeamentoEntidade = Substitute.For<IAdministradorMapeamentoEntidade>();

            //_contexto = Substitute.For<OrcamentoContexto>();

            _administradorServico = new AdministradorServico(_administradorRepositorio, _administradorMapeamentoEntidade, _contexto);
        }
        [Fact]
        public void Test_Apagar()
        {
            //Arrange
            var id = 10;

            //Act
            _administradorServico.Apagar(id);

            //Assert
            _administradorRepositorio.Received().Apagar(Arg.Is(10));
        }

        [Fact]
        public void Test_Cadastrar()
        {
            //Arrange
            var viewModel = new AdministradorCadastrarViewModel
            {
                Nome = "Pedro",
                Cpf = "122.222.312-12",
                Email = "jose@gmail.com",
                DataNascimento = Convert.ToDateTime("2001/03/03"),
                Endereco = "rua palmeiras 201",
                Telefone = "99772-1079",
                Login = "navio",
                Senha = "calabresa".GerarHash(),
            };
            //Act
            _administradorServico.Cadastrar(viewModel);

            //Assert
            _administradorRepositorio.Received(1).Cadastrar(Arg.Is<Administrador>(
                administrador => ValidarAdministrador(administrador, viewModel)));
        }



        private bool ValidarAdministrador(Administrador administrador, AdministradorCadastrarViewModel viewModel)
        {
            administrador.Nome.Should().Be(viewModel.Nome);
            administrador.Cpf.Should().Be(viewModel.Cpf);
            administrador.Email.Should().Be(viewModel.Email);
            administrador.DataNascimento.Should().Be(viewModel.DataNascimento);
            administrador.Endereco.Should().Be(viewModel.Endereco);
            administrador.Telefone.Should().Be(viewModel.Telefone);
            administrador.Login.Should().Be(viewModel.Login);
            administrador.Senha.Should().Be(viewModel.Senha.GerarHash());

            return true;
        }

    }
}
