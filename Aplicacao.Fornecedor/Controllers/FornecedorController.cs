using Servico.Servicos;

namespace Aplicacao.Fornecedor.Controllers
{
    //[Route("fornecedor")]
    public class FornecedorController
    {
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorController(IFornecedorServico fornecedorServico)
        {
            _fornecedorServico = fornecedorServico;
        }
    }
}