using NSubstitute;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.Servicos;
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

            _administradorServico = new AdministradorServico(_administradorRepositorio, _administradorMapeamentoEntidade);
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

    }
}
