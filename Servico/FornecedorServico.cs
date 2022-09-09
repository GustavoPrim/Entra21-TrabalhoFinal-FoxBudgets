using Repositorio.Repositorios;

namespace Servico
{
    public class FornecedorServico
    {
        private readonly IFornecedorReposistorio _fornecedorRepositorio;
        private readonly IFornecedorMapeamentoEntidade _mapeamento;

        public FornecedorServico(IFornecedorReposistorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

    }
}
