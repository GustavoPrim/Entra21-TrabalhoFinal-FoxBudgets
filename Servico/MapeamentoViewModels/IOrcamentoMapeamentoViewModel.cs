using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.MapeamentoViewModels
{
    public interface IOrcamentoMapeamentoViewModel
    {
        OrcamentoEditarViewModel ConstruirCom(Orcamento orcamento);
    }
}
