using Repositorio.BancoDados;
using Repositorio.Entidades;
using System.Data.Entity;

namespace Repositorio.Repositorios
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public EstoqueRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var estoque = _contexto.Estoque
                .FirstOrDefault(x => x.Id == id);

            if (estoque == null)
                return false;

            _contexto.Estoque.Remove(estoque);
            _contexto.SaveChanges();

            return true;
        }

        public Estoque CadastrarQuantidade(Estoque quantidade)
        {
            _contexto.Estoque.Add(quantidade);
            _contexto.SaveChanges();

            return quantidade;
        }

        public Estoque CadastrarValor(Estoque valor)
        {
            _contexto.Estoque.Add(valor);
            _contexto.SaveChanges();

            return valor;
        }

        public void Editar(Estoque estoque)
        {
            _contexto.Estoque.Update(estoque);
            _contexto.SaveChanges();
        }

        public Estoque ObterPorId(int id) =>
            _contexto.Estoque
            .FirstOrDefault(x => x.Id == id);

        public IList<Estoque> ObterTodos() =>
            _contexto.Estoque
            .ToList();
    }
}
