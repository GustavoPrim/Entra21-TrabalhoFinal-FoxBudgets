using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
        }

        public void Cadastrar(ClienteCadastrarViewModel viewModel)
        {
            var cliente = _mapeamento.ConstruirCom()
        }

        public bool Editar(ClienteEditarViewModel viewModel)
        {
            var cliente = _clienteRepositorio.ObterPorId(viewModel.Id);

            if (cliente == null)
                return false;

            //_mapeamento.AtualizarCampos(cliente, viewModel);
            _clienteRepositorio.Atualizar(cliente);

            return true;
        }

        public Cliente? ObterPorId(int id) =>
            _clienteRepositorio.ObterPorId(id);

        public IList<Cliente> ObterTodos() =>
            _clienteRepositorio.ObterTodos();
    }
}