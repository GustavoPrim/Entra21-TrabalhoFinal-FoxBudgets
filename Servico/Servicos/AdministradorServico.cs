using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IAdministradorMapeamentoEntidade _mapeamentoEntidade;
        private readonly OrcamentoContexto _contexto;
        

        public AdministradorServico(
            IAdministradorRepositorio administradorRepositorio,
            IAdministradorMapeamentoEntidade mapeamentoEntidade,
            OrcamentoContexto contexto)
        {
            _administradorRepositorio = administradorRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
            _contexto = contexto;
        }

        public bool Apagar(int id) =>
            _administradorRepositorio.Apagar(id);

        public Administrador Cadastrar(AdministradorCadastrarViewModel viewModel)
        {
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