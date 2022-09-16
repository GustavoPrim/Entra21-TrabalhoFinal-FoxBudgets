using Repositorio.BancoDados;
using Repositorio.Entidades;
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

        public void Atualizar(Adm administradorParaAlterar)
        {
            var administradores = _contexto.Administradores
                .Where(x => x.Id == administradorParaAlterar.Id)
                .FirstOrDefault();
        }

        public Adm BuscarPorLogin(string login)
        {
           return _contexto.Administradores.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        public Adm Cadastrar(Adm administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public void Editar(Adm administrador)
        {
            _contexto.Administradores.Update(administrador);
            _contexto.SaveChanges();
        }

        public Adm ObterPorId(int id) =>
            _contexto.Administradores
            .Include(x => x.Administradores)
            .FirstOrDefault(x => x.Id == id);
        

        public IList<Adm> ObterTodos() =>
            _contexto.Administradores
                 .Include(x => x.Administradores)
                 .ToList();
    }
}