using Aplicacao.Administradores;
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

        //public AdministradorServico(
        //    IAdministradorRepositorio administradorRepositorio,
        //    IAdministradorMapeamentoEntidade mapeamentoEntidade)
        //{
        //    _administradorRepositorio = administradorRepositorio;
        //    _mapeamentoEntidade = mapeamentoEntidade;
        //}

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

    }
}
