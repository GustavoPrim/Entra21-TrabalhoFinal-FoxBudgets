﻿using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(ClienteContexto contexto)
        {
            _clienteRepositorio = new ClienteRepositorio(contexto);
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
        }

        public void Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel)
        {
            var cliente = new Cliente();
            cliente.Cpf = clienteCadastrarViewModel.Cpf;
            cliente.DataNascimento = clienteCadastrarViewModel.DataNascimento;
            cliente.Endereco = clienteCadastrarViewModel.Endereco;
            cliente.Email = clienteCadastrarViewModel.Email;
            cliente.Telefone = clienteCadastrarViewModel.Telefone;
            cliente.Cnpj = clienteCadastrarViewModel.Cnpj;
        }

        public void Editar(ClienteEditarViewModel clienteEditarViewModel)
        {
            var cliente = new Cliente();
            cliente.Cpf = clienteEditarViewModel.Cpf;
            cliente.DataNascimento = clienteEditarViewModel.DataNascimento;
            cliente.Endereco = clienteEditarViewModel.Endereco;
            cliente.Email = clienteEditarViewModel.Email;
            cliente.Telefone = clienteEditarViewModel.Telefone;
            cliente.Cnpj = clienteEditarViewModel.Cnpj;

            _clienteRepositorio.Atualizar(cliente);
        }

        public void ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}