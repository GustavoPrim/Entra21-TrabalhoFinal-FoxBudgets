﻿using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        bool Apagar(int id);
        Cliente Cadastrar(Cliente cliente);
        void Editar(Cliente clienteParaAlterar);
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}