﻿using Repositorio.BancoDados;
using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public ClienteRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var cliente = _contexto.Clientes
                .FirstOrDefault(x => x.Id == id);

            if (cliente == null)
                return false;

            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();

            return true;
        }

        public void Atualizar(Cliente clienteParaAlterar)
        {
            var administradores = _contexto.Administradores
                .Where(x => x.Id == clienteParaAlterar.Id)
                .FirstOrDefault();
        }

        public Cliente Cadastrar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();

            return cliente;
        }
        
        public void Editar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
            _contexto.SaveChanges();
        }

        public Cliente? ObterPorId(int id) =>
            _contexto.Clientes
            .FirstOrDefault(x => x.Id == id);

        public IList<Cliente> ObterTodos() =>
            _contexto.Clientes.ToList();
    }
}