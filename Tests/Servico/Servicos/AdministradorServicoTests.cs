using FluentAssertions;
using NSubstitute;
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


        public AdministradorServicoTests()
        {
            _administradorRepositorio = Substitute.For<IAdministradorRepositorio>();

            _administradorMapeamentoEntidade = Substitute.For<IAdministradorMapeamentoEntidade>();

            //_administradorServico = new AdministradorServico(_administradorRepositorio, _administradorMapeamentoEntidade);
        }
        [Fact]
        public void Test_Apagar()
        {
            //Arrange
            var id = 30;

            //Act
            _administradorServico.Apagar(id);

            //Assert
            _administradorRepositorio.Received().Apagar(Arg.Is(30));
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
                Senha = "calabresa",
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

            return true;
        }

    }
}
