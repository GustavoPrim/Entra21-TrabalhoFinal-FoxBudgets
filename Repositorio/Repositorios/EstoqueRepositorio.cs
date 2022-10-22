using Repositorio.BancoDados;
using Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

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

        public Estoque Cadastrar(Estoque quantidade)
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

        public void CriarOuAtualizar(Estoque estoque)
        {
            if (estoque.Id == 0)
                _contexto.Estoque.Add(estoque);
            else
                _contexto.Estoque.Update(estoque);

            _contexto.SaveChanges();
        }

        public void Editar(Estoque estoque)
        {
            _contexto.Estoque.Update(estoque);
            _contexto.SaveChanges();
        }

        public List<Estoque> ObterTodosPorFornecedorId(int idFornecedor)
        {
            return
                _contexto.Estoque
                .Where(x => x.FornecedorId == idFornecedor)
                .Include(x => x.Material)
                .ToList();
        }

        public Estoque ObterPorId(int id) =>
            _contexto.Estoque
            .FirstOrDefault(x => x.Id == id);

        public IList<Estoque> ObterTodos() =>
            _contexto.Estoque
            .ToList();

        public Estoque? ObterPorFornecedorId(int fornecedorId, int item)
        {
            return
                _contexto.Estoque
                .Where(x => x.FornecedorId == fornecedorId && x.MaterialId == item)
                .Include(x => x.Material)
                .FirstOrDefault();
        }
    }
}
