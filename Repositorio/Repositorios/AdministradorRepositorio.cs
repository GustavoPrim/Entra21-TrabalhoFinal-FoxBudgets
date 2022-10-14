﻿using Repositorio.BancoDados;
using Repositorio.Entidades;
<<<<<<< HEAD
=======
using System.Data.Entity;
>>>>>>> 5d94284bbcdff9e41a73e6015460075ba4bb0490

namespace Repositorio.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public AdministradorRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var administrador = _contexto.Administradores
                .FirstOrDefault(x => x.Id == id);

            if (administrador == null)
                return false;

            _contexto.Administradores.Remove(administrador);
            _contexto.SaveChanges();

            return true;
        }

        public void Atualizar(Administrador administradorParaAlterar)
        {
            var administradores = _contexto.Administradores
                .Where(x => x.Id == administradorParaAlterar.Id)
                .FirstOrDefault();
        }

        public Administrador? BuscarPorLogin(string login, string senha) =>
            _contexto.Administradores.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Senha == senha.GerarHash());

        public Administrador Cadastrar(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public void Editar(Administrador administrador)
        {
            _contexto.Administradores.Update(administrador);
            _contexto.SaveChanges();
        }

        public Administrador? ObterPorId(int id) =>
            _contexto.Administradores
            .FirstOrDefault(x => x.Id == id);


        public IList<Administrador> ObterTodos() =>
            _contexto.Administradores
                 .ToList();
    }
}