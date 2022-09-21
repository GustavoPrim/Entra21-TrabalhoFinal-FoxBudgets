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
        public void Atualizar(Orcamento orcamentoParaAlterar)
        {
            var orcamentos = _contexto.Orcamentos
                .Where(x => x.Id == orcamentoParaAlterar.Id)
                .FirstOrDefault();
        }
        public void Editar(Orcamento orcamento)
        {
            _contexto.Orcamentos.Update(orcamento);
            _contexto.SaveChanges();
        }
        public Orcamento ObterPorId(int id) =>
            _contexto.Orcamentos
            .Include(x => x.OrcamentoMateriais)
            .FirstOrDefault(x => x.Id == id);
        public IList<Orcamento> ObterTodos() =>
            _contexto.Orcamentos
                .Include(x => x.OrcamentoMateriais)
                .ToList();
        public Orcamento Solicitar(Orcamento orcamento)
        {
            _contexto.Orcamentos.Add(orcamento);
            _contexto.SaveChanges();

            return orcamento;
        }
    }
}
