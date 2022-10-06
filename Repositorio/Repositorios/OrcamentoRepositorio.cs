using Repositorio.BancoDados;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class OrcamentoRepositorio : IOrcamentoRepositorio
    {
        private readonly OrcamentoContexto _contexto;
        public bool Apagar(int id)
        {
            var orcamento = _contexto.Orcamentos
                .FirstOrDefault(x => x.Id == id);

            if (orcamento == null)
                return false;

            _contexto.Orcamentos.Remove(orcamento);
            _contexto.SaveChanges();

            return true;
        }
        public void Atualizar(OrcamentoMaterial orcamentoParaAlterar)
        {
            var orcamentos = _contexto.Orcamentos
                .Where(x => x.Id == orcamentoParaAlterar.Id)
                .FirstOrDefault();
        }
        public void Editar(OrcamentoMaterial orcamento)
        {
            _contexto.Orcamentos.Update(orcamento);
            _contexto.SaveChanges();
        }
        public OrcamentoMaterial? ObterPorId(int id) 
        {
            var orcamento = _contexto.Orcamentos.Where(x => x.Id == id).FirstOrDefault();
            return orcamento;
        }
        public List<OrcamentoMaterial> ObterTodos() 
        {
            var orcamentos = _contexto.Orcamentos.ToList();
            return orcamentos;
        }

        public OrcamentoMaterial Cotar(OrcamentoMaterial orcamento)
        {
            //fazer lógica do método cotar
            return orcamento;
        }
    }
}
