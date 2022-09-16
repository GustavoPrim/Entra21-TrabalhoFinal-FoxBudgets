using Repositorio.BancoDados;
using Repositorio.Entidades;
using System.Data.Entity;

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
        public void Atualizar(Fornecedor fornecedorAlterar)
        {
            var fornecedores = _contexto.Fornecedores
                .Where(x => x.Id == fornecedorAlterar.Id)
                .FirstOrDefault();
        }

        public Fornecedor Cadastrar(Fornecedor fornecedor)
        {
            _contexto.Fornecedores.Add(fornecedor);
            _contexto.SaveChanges();

            return fornecedor;
        }

        public void Editar(Fornecedor fornecedorParaAlterar)
        {
            _contexto.Fornecedores.Update(fornecedorParaAlterar);
            _contexto.SaveChanges();
        }

        public Fornecedor? ObterPorId(int id) =>
            _contexto.Fornecedores
            .FirstOrDefault(x => x.Id == id);

        public IList<Fornecedor> ObterTodos() =>

            _contexto.Fornecedores
            .ToList();
    }
}