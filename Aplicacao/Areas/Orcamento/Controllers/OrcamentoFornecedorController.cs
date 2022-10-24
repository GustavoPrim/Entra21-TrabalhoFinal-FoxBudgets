using Aplicacao.Filtros;
using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace Aplicacao.Areas.Orcamento.Controllers
{
    [UsuarioLogado]
    public class OrcamentoFornecedorController : Controller
    {
        private readonly IEstoqueServico _estoqueServico;
        private readonly ISessao _sessao;
        private readonly IMaterialService _materialService;
    }
}
