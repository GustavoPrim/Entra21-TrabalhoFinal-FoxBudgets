using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private readonly AdministrradorContexto _contexto;

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
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
        }

        public Administrador ObterPorId(int id)
        {
            var administrador = _contexto.Administradores.Where(x => x.Id == id).FirstOrDefault();

            return administrador;
        }

        public List<Administrador> ObterTodos()
        {
            var administrador = _contexto.Administradores.ToList();

            return administrador;
        }
    }
}
