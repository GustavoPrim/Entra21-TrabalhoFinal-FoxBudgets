using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteMapeamentoEntidade _mapeamento;

        public ClienteService(
            IClienteRepositorio clienteRepositorio,
            IClienteMapeamentoEntidade mapeamento)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapeamento = mapeamento;
        }

        public bool Apagar(int id) =>
            _clienteRepositorio.Apagar(id);

        public Cliente Cadastrar(ClienteCadastrarViewModel viewModel)
        {
            var cliente = _mapeamento.ConstruirCom(viewModel);
            _clienteRepositorio.Cadastrar(cliente);
            return cliente;
        }

        public bool Editar(ClienteEditarViewModel viewModel)
        {
            var cliente = _clienteRepositorio.ObterPorId(viewModel.Id);

            if (cliente == null)
                return false;

            _mapeamento.AtualizarCampos(cliente, viewModel);
            _clienteRepositorio.Editar(cliente);
            return true;
        }

        public Cliente? ObterPorId(int id) =>
            _clienteRepositorio.ObterPorId(id);

        public IList<Cliente> ObterTodos() =>
            _clienteRepositorio.ObterTodos();
    }
}