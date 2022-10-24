using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Orcamentos;
using System.Data.Entity.Core;

namespace Servico.Servicos
{
    public class OrcamentoServico : IOrcamentoServico
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;
        private readonly IOrcamentoMapeamentoEntidade _mapeamentoEntidade;

        public OrcamentoServico(
            IOrcamentoRepositorio orcamentoRepositorio, IOrcamentoMapeamentoEntidade mapeamentoEntidade)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }
        public bool Apagar(int id) =>
            _orcamentoRepositorio.Apagar(id);

        public bool Editar(OrcamentoEditarViewModel viewModel)
        {
            //var orcamento = _orcamentoRepositorio.ObterPorId(viewModel.Id);

            //if (orcamento == null)
            //    return false;

            //_mapeamentoEntidade.AtualizarCom(orcamento, viewModel);
            //_orcamentoRepositorio.Editar(orcamento);

            return true;
        }

        public Orcamento ObterPorId(int id) =>
            _orcamentoRepositorio.ObterPorId(id);

        public List<Orcamento> ObterTodos() =>
            _orcamentoRepositorio.ObterTodos();

        public Orcamento Cotar(OrcamentoCadastrarViewModel viewModel, int clienteId)
        {
            var orcamento = _orcamentoRepositorio.ObterPorClienteId(clienteId);

            if (orcamento == null)
                orcamento = new Orcamento
                {
                    ClienteId = clienteId,
                    OrcamentoMateriais = new List<OrcamentoMaterial>()
                };

            var orcamentoMaterial = _mapeamentoEntidade.ConstruirCom(viewModel);

            orcamento.OrcamentoMateriais.Add(orcamentoMaterial);

            _orcamentoRepositorio.CrirOuAtualizar(orcamento);

            return orcamento;
        }

        public List<OrcamentoItemIndexViewModel> ObterItensOrcamentoAtual(int idUsuarioLogado)
        {
            var orcamento = _orcamentoRepositorio.ObterPorClienteId(idUsuarioLogado);

            if(orcamento == null)
                return new List<OrcamentoItemIndexViewModel>();

            return orcamento.OrcamentoMateriais.Select(
                x => new OrcamentoItemIndexViewModel
                {
                    Material = x.Material.Nome,
                    OrcamentoMaterialId = x.Id,
                    Quantidade = x.Quantidade
                }).ToList();
        }

        public List<OrcamentoMaterialViewModel> Calcular(int clienteId)
        {
            var orcamento = _orcamentoRepositorio.ObterOrcamentoPorClienteId(clienteId);

            var materiais = new List<OrcamentoMaterialViewModel>();

            foreach (var orcamentoMaterial in orcamento.OrcamentoMateriais)
            {
                var estoques = _orcamentoRepositorio
                    .ObterEstoquePorMaterialId(orcamentoMaterial.MaterialId, orcamentoMaterial.Quantidade);

                var material = new OrcamentoMaterialViewModel
                {
                    Item = orcamentoMaterial.Material.Nome,
                    Quantidade = orcamentoMaterial.Quantidade
                };

                foreach (var estoque in estoques)
                {
                    material.Fornecedores.Add(new OrcamentoFornecedorViewModel
                    {
                        Nome = estoque.Fornecedor.Nome,
                        Valor = estoque.Valor * material.Quantidade,
                        ValorUnitario = estoque.Valor
                    });
                }

                materiais.Add(material);
            }

            return materiais;
        }
    }
}
