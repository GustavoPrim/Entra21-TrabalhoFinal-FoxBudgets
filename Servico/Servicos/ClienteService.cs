﻿using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteMapeamentoEntidade _mapeamento;

        public ClienteService(
            IClienteRepositorio clienteRepositorio,
            IClienteMapeamentoEntidade mapeamentoEntidade)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapeamento = mapeamentoEntidade;
        }
        public bool Apagar(int id) =>
            _clienteRepositorio.Apagar(id);

        public Cliente BuscarPorLogin(string login, string senha)
        {
            var cliente = _clienteRepositorio.BuscarPorLogin(login, senha);

            return cliente;
        }

        public Cliente Cadastrar(CadastrarUsuarioViewModel viewModel)
        {
            var cliente = _mapeamento.ConstruirCom(viewModel);
            _clienteRepositorio.Cadastrar(cliente);
            return cliente;
        }

        public bool Editar(ClienteEditarViewModel viewModelEditar)
        {
            var cliente = _clienteRepositorio.ObterPorId(viewModelEditar.Id);

            if (cliente == null)
                return false;

            _mapeamento.AtualizarCampos(cliente, viewModelEditar);

            _clienteRepositorio.Editar(cliente);
            return true;
        }

        public Cliente? ObterPorId(int id) =>
            _clienteRepositorio.ObterPorId(id);
        public IList<Cliente> ObterTodos() =>
            _clienteRepositorio.ObterTodos();
    }
}