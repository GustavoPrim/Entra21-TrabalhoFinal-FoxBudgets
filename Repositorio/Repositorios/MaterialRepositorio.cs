using Repositorio.BancoDados;
using Repositorio.Entidades;
using System.Data.Entity;

namespace Repositorio.Repositorios
{
    public class MaterialRepositorio : IMaterialRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public MaterialRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var material = _contexto.Materiais
                .FirstOrDefault(x => x.Id == id);

            if (material == null)
                return false;

            _contexto.Materiais.Remove(material);
            _contexto.SaveChanges();

            return true;
        }

        public Material CadastrarMateriais(Material material)
        {
            _contexto.Materiais.Add(material);
            _contexto.SaveChanges();

            return material;
        }

        public void EditarMateriais(Material material)
        {
            _contexto.Materiais.Update(material);
            _contexto.SaveChanges();
        }

        public Material? ObterPorId(int id) =>
            _contexto.Materiais.Where(x => x.Id == id)
            .FirstOrDefault();

        public IList<Material> ObterTodos() =>
            _contexto.Materiais.ToList();
    }
}