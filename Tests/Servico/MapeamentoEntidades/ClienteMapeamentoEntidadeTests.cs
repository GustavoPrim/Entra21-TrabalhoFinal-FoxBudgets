using FluentAssertions;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;
using Xunit;

namespace Tests.Servico.MapeamentoEntidades
{
    public class ClienteMapeamentoEntidadeTests
    {
        private readonly IClienteMapeamentoEntidade _clienteMapeamentoEntidades;

        public ClienteMapeamentoEntidadeTests()
        {
            _clienteMapeamentoEntidades = new ClienteMapeamentoEntidade();
        }

        [Fact]
        public void Test_construirCom()
        {
            //Arrange
            var viewModel = new CadastrarUsuarioViewModel
            {
                Nome = "William",
                Cnpj = "12.345.678/0001-90",
                Cpf = "788.122.454-90",
                DataNascimento = Convert.ToDateTime("2002/06/20"),
                Email = "willdev@gmail.com",
                Endereco = "Rua maca",
                Telefone = "99445-2245",
                Login = "wiil",
                Senha = "1221".GerarHash()
            };
            //Act
            var cliente = _clienteMapeamentoEntidades.ConstruirCom(viewModel);

            //Assert
            cliente.Nome.Should().Be(viewModel.Nome);
            cliente.Cnpj.Should().Be(viewModel.Cnpj);
            cliente.Cpf.Should().Be(viewModel.Cpf);
            cliente.DataNascimento.Should().Be(viewModel.DataNascimento);
            cliente.Email.Should().Be(viewModel.Email);
            cliente.Endereco.Should().Be(viewModel.Endereco);
            cliente.Telefone.Should().Be(viewModel.Telefone);
            cliente.Login.Should().Be(viewModel.Login);
            cliente.Senha.Should().Be(viewModel.Senha.GerarHash());
        }

        [Fact]
        public void Test_AtualizarCom()
        {
            //Arrange
            var cliente = new Cliente()
            {
                Id = 1,
                Nome = "João",
                Cnpj = "12.322.678/0201-60",
                Cpf = "155.121.544-20",
                DataNascimento = Convert.ToDateTime("2004/12/04"),
                Email = "joaoprim@gmail.com",
                Endereco = "rua dos calvos",
                Telefone = "99221-1022",
                Login = "calvo",
                Senha = "1221"
            };
            var clienteEditar = new ClienteEditarViewModel
            {
                Id = cliente.Id,
                Nome = "joao dois",
                Cnpj = "12.333.422/0007-22",
                Cpf = "177.154.762-11",
                DataNascimento = Convert.ToDateTime("1222/03/12"),
                Email = "joaoDois@gmail.com",
                Endereco = "rua desenvolvedora",
                Telefone = "99331-1032",
                Login = "desenvolvedor",
                Senha = "desenvolvedor01"
            };
            //Act
            _clienteMapeamentoEntidades.AtualizarCampos(cliente, clienteEditar);

            //Assert
            cliente.Id.Should().Be(clienteEditar.Id);
            cliente.Nome.Should().Be(clienteEditar.Nome);
            cliente.Cnpj.Should().Be(clienteEditar.Cnpj);
            cliente.Cpf.Should().Be(clienteEditar.Cpf);
            cliente.DataNascimento.Should().Be(clienteEditar.DataNascimento);
            cliente.Email.Should().Be(clienteEditar.Email);
            cliente.Endereco.Should().Be(clienteEditar.Endereco);
            cliente.Telefone.Should().Be(clienteEditar.Telefone);
            cliente.Login.Should().Be(clienteEditar.Login);
            cliente.Senha.Should().Be(clienteEditar.Senha);

        }
    }
}
