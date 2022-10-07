using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IAdministradorMapeamentoEntidade _mapeamentoEntidade;
        private IAdministradorRepositorio administradorRepositorio;

        public AdministradorServico(
            IAdministradorRepositorio administradorRepositorio,
            IAdministradorMapeamentoEntidade mapeamentoEntidade)
        {
            _administradorRepositorio = administradorRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }

        public AdministradorServico(IAdministradorRepositorio administradorRepositorio)
        {
            this.administradorRepositorio = administradorRepositorio;
        }

        public bool Apagar(int id) =>
            _administradorRepositorio.Apagar(id);

        public Administrador Cadastrar(AdministradorCadastrarViewModel viewModel)
        {
            //viewModel.Senha = viewModel.Senha.GerarHash();

            var administrador = _mapeamentoEntidade.ConstruirCom(viewModel);

            _administradorRepositorio.Cadastrar(administrador);
            return administrador;
        }

        public bool Editar(AdministradorEditarViewModel viewModel)
        {
            var administrador = _administradorRepositorio.ObterPorId(viewModel.Id);

            if (administrador == null)
                return false;

            _mapeamentoEntidade.AtualizarCom(administrador, viewModel);
            _administradorRepositorio.Editar(administrador);

            return true;
        }

        public Administrador? ObterPorId(int id) =>
            _administradorRepositorio.ObterPorId(id);

        public IList<Administrador> ObterTodos() =>
            _administradorRepositorio.ObterTodos();

        public Administrador BuscarPorLogin(string login, string senha)
        {
            var administrador = _administradorRepositorio.BuscarPorLogin(login, senha);

            return administrador;
        }
    }
}