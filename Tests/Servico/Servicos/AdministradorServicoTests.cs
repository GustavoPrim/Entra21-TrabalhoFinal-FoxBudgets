using NSubstitute;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.Servicos;

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


    }
}
