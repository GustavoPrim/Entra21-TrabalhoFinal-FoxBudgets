using Microsoft.AspNetCore.Http;
using Repositorio.BancoDados;
using Repositorio.Entidades;
using Servico.ViewModels;
using System.Data.Entity;

namespace Repositorio.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public AdministradorRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        //public Administrador AlterarSenha(AlterarSenhaViewModel alterarSenha, Usuario usuario, )
        //{
        //    // BUSCAR DO BANCO COM LOGIN E SENHA

        //    //Administrador? BuscarPorLogin(string login, string senha) =>
        //    //_contexto.Administradores.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Senha == senha.GerarHash());


        //    // VERIFICAR SE ENCONTROU O ADMINISTRADOR
          

        //    // PREENCHER A SENHA DO ADMINISTRADOR ENCONTRADO COM A NOVA SENHA, LEMBRAR DE GERAR HASH
        //    // CHAMA O ATUALIZAR DO EF
        //}

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