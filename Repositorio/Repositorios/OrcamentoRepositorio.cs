﻿using Microsoft.EntityFrameworkCore;
using Repositorio.BancoDados;
using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class OrcamentoRepositorio : IOrcamentoRepositorio
    {
        private readonly OrcamentoContexto _contexto;

        public OrcamentoRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

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

        public void Editar(Orcamento orcamento)
        {
            _contexto.Orcamentos.Update(orcamento);
            _contexto.SaveChanges();
        }

        public Orcamento? ObterPorClienteId(int idCliente)
        {
            var orcamento = _contexto.Orcamentos
                .Where(x => x.ClienteId == idCliente)
                .Include(x => x.OrcamentoMateriais)
                .ThenInclude(x => x.Material)
                .FirstOrDefault();
            return orcamento;
        }

        public Orcamento? ObterPorId(int id)
        {
            var orcamento = _contexto.Orcamentos.Where(x => x.Id == id).FirstOrDefault();
            return orcamento;
        }

        public List<Orcamento> ObterTodos()
        {
            var orcamentos = _contexto.Orcamentos.ToList();
            return orcamentos;
        }

        public Orcamento Cotar(Orcamento orcamento)
        {
            //fazer lógica do método cotar
            return orcamento;
        }

        public void CrirOuAtualizar(Orcamento orcamento)
        {
            if (orcamento.Id == 0)
                _contexto.Orcamentos.Add(orcamento);
            else
                _contexto.Orcamentos.Update(orcamento);

            _contexto.SaveChanges();
        }

        public Orcamento? ObterOrcamentoPorClienteId(int clienteId)
        {
            // show isso está correto, : emoji feliz
            return
                _contexto.Orcamentos
                .Where(x => x.ClienteId == clienteId)
                .Include(x => x.OrcamentoMateriais)
                .ThenInclude(x => x.Material)
                .FirstOrDefault();
        }

        public List<Estoque> ObterEstoquePorMaterialId(int materialId, int quantidadeNecessaria)
        {
            return _contexto.Estoque
                .Where(x => x.MaterialId == materialId && x.Quantidade >= quantidadeNecessaria)
                .Include(x => x.Fornecedor)
                .OrderBy(x => x.Valor)
                .ToList();
        }
    }
}