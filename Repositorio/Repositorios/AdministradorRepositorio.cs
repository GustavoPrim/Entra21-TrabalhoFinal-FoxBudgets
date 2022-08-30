using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    internal class AdministradorRepositorio : IAdministradorRepositorio
    {
        //private readonly AdministradorContexto _contexto;

        //public AdministradorRepositorio(AdministadorContexto contexto)
        //{
        //    _contexto = contexto;
        //}
        public void Apagar(int id)
        {
            var administrador = _contexto.Administradores.Where(x => x.Id == id).FirstOrDefault();

            _contexto.Administradores.Remove(administrador);
            _contexto.SaveChanges();
        }

        public void Atualizar(Administrador administradorParaAlterar)
        {
            var administradores = _contexto.Administradores
                .Where(x => x.Id == administradorParaAlterar.Id).FirstOrDefault();
        }

        public void Cadastrar(Administrador administrador)
        {
            throw new NotImplementedException();
        }

        public Administrador ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrador> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
