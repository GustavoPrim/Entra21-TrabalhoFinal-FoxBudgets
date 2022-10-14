using FluentAssertions;
using NSubstitute.ReturnsExtensions;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Administradores;
using Xunit;

namespace Tests.Servico.MapeamentoEntidades
{
    public class AdministradorMapeamentoEntidadeTests
    {
        private readonly IAdministradorMapeamentoEntidade _administradorMapeamentoEntidades;

        public AdministradorMapeamentoEntidadeTests()
        {
            _administradorMapeamentoEntidades = new AdministradorMapeamentoEntidade();
        }

        [Fact]
        public void Test_construirCom()
        {
            //Arrange
            var viewModel = new AdministradorCadastrarViewModel
            {
                Nome = "João",
                Cpf = "138.117.329-27",
                DataNascimento = Convert.ToDateTime("2022/02/22"),
                Email = "administrador@gmail.com",
                Endereco = "Rua Thomé de Souza 157",
                Telefone = "99772-1079",
                Login = "ccc",
                Senha = "123456".GerarHash(),
            };
           // Act
            var administrador = _administradorMapeamentoEntidades.ConstruirCom(viewModel);

            //Assert
            administrador.Nome.Should().Be(viewModel.Nome);
            administrador.Cpf.Should().Be(viewModel.Cpf);
            administrador.DataNascimento.Should().Be(viewModel.DataNascimento);
            administrador.Email.Should().Be(viewModel.Email);
            administrador.Endereco.Should().Be(viewModel.Endereco);
            administrador.Telefone.Should().Be(viewModel.Telefone);
            administrador.Login.Should().Be(viewModel.Login);
            administrador.Senha.Should().Be(viewModel.Senha.GerarHash());
        }

        [Fact]
        public void Test_atualizarCom()
        {
            //Arrange
            var administrador = new Administrador
            {
                Id = 1,
                Nome = "José",
                Cpf = "155.323.111-22",
                DataNascimento = Convert.ToDateTime("2022/01/02"),
                Email = "jose@gmail.com",
                Endereco = "rua das palmeiras",
                Telefone = "99887-7655",
                Login = "kkk",
                Senha = "12345".GerarHash()
            };
            var administradorEditar = new AdministradorEditarViewModel
            {
                Id = 1,
                Nome = "José Pereira",
                Cpf = "156.322.112-23",
                DataNascimento = Convert.ToDateTime("2001/05/25"),
                Email = "josetrabalhador@gmail.com",
                Endereco = "rua das cativeiras",
                Telefone = "99883-5566",
                Login = "kkc",
                Senha = "12344".GerarHash()
            };

            //Act
            _administradorMapeamentoEntidades.AtualizarCom(administrador, administradorEditar);


            //Assert
            administrador.Id.Should().Be(administradorEditar.Id);
            administrador.Nome.Should().Be(administradorEditar.Nome);
            administrador.Cpf.Should().Be(administradorEditar.Cpf);
            administrador.DataNascimento.Should().Be(administradorEditar.DataNascimento);
            administrador.Email.Should().Be(administradorEditar.Email);
            administrador.Endereco.Should().Be(administradorEditar.Endereco);
            administrador.Telefone.Should().Be(administradorEditar.Telefone);
            administrador.Login.Should().Be(administradorEditar.Login);
            administrador.Senha.Should().Be(administradorEditar.Senha);
        }
    }
}
