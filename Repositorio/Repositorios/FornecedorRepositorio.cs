using Repositorio.BancoDados;
using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class FornecedorRepositorio : IFornecedorReposistorio
    {
        private readonly OrcamentoContexto _contexto;

        public FornecedorRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var fornecedor = _contexto.Fornecedores
                .FirstOrDefault(x => x.Id == id);

            if (fornecedor == null)
                return false;

            _contexto.Fornecedores.Remove(fornecedor);
            _contexto.SaveChanges();

            return true;
        }

        public Fornecedor Cadastrar(Fornecedor fornecedor)
        {
            _contexto.Fornecedores.Add(fornecedor);
            _contexto.SaveChanges();

            return fornecedor;
        }

        public void Editar(Fornecedor fornecedorParaAlterar)
        {
            var fornecedor = _contexto.Fornecedores
                .Where(x => x.Id == fornecedorParaAlterar.Id)
                .FirstOrDefault();
        }

        public Fornecedor? ObterPorId(int id) =>
            _contexto.Fornecedores.Where(x => x.Id == id)
            .FirstOrDefault();

        public IList<Fornecedor> ObterTodos() =>
            _contexto.Fornecedores.ToList();
    }
}