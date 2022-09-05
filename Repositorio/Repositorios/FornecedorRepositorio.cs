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
        public void Apagar(int id)
        {
            var fornecedor = _contexto.Fornecedores.Where(x => x.Id == id).FirstOrDefault();

            _contexto.Fornecedores.Remove(fornecedor);
            _contexto.SaveChanges();
        }

        public void Atualizar(Fornecedor fornecedorParaAlterar)
        {
            var fornecedor = _contexto.Fornecedores
                .Where(x => x.Id == fornecedorParaAlterar.Id).FirstOrDefault();

            fornecedor.Nome = fornecedorParaAlterar.Nome;
            fornecedor.Cnpj = fornecedorParaAlterar.Cnpj;
            fornecedor.Endereco = fornecedorParaAlterar.Endereco;
            fornecedor.Categoria = fornecedorParaAlterar.Categoria;
            fornecedor.DataFundacao = fornecedorParaAlterar.DataFundacao;
            fornecedor.Email = fornecedorParaAlterar.Email;

            _contexto.Update(fornecedor);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Fornecedor fornecedor)
        {
            _contexto.Fornecedores.Add(fornecedor);
            _contexto.SaveChanges();
        }

        public Fornecedor ObterPorId(int id)
        {
            var fornecedor = _contexto.Fornecedores
                .Where(x => x.Id == id).FirstOrDefault();

            return fornecedor;
        }

        public List<Fornecedor> ObterTodos()
        {
            var fornecedores = _contexto.Fornecedores.ToList();
            return fornecedores;
        }
    }
}