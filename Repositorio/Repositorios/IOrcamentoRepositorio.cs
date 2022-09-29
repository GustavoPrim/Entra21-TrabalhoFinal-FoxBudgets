using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public interface IOrcamentoRepositorio
    {
        OrcamentoMaterial Cotar(OrcamentoMaterial orcamentoMaterial);
        void Editar(OrcamentoMaterial orcamentoMaterial);
        OrcamentoMaterial ObterPorId(int id);
        List<OrcamentoMaterial> ObterTodos();
        bool Apagar(int id);
    }
}
