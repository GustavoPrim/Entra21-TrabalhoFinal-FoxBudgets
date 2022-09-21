using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.MapeamentoViewModels
{
    public class OrcamentoMapeamentoViewModel : IOrcamentoMapeamentoViewModel
    {
        public OrcamentoEditarViewModel ConstruirCom(Orcamento orcamento)
        {
            return new OrcamentoEditarViewModel
            {
                Id = orcamento.Id,
                DataOrcamento = orcamento.DataOrcamento,
                Item = orcamento.Item,
                Quantidade = orcamento.Quantidade,
            };
        }
    }
}
