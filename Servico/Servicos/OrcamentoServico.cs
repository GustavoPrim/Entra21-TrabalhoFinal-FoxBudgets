using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.Servicos
{
    public class OrcamentoServico : IOrcamentoServico
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;
        private readonly IOrcamentoMapeamentoEntidade _mapeamentoEntidade;
        
        public OrcamentoServico(
            IOrcamentoRepositorio orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }
        public bool Apagar(int id) =>
            _orcamentoRepositorio.Apagar(id);
        

        public bool Editar(OrcamentoEditarViewModel viewModel)
        {
            var orcamento = _orcamentoRepositorio.ObterPorId(viewModel.Id);

            if (orcamento == null)
                return false;

            _mapeamentoEntidade.AtualizarCom(orcamento, viewModel);
            _orcamentoRepositorio.Editar(orcamento);

            return true;
        }

        public Orcamento ObterPorId(int id) =>
            _orcamentoRepositorio.ObterPorId(id);

        public IList<Orcamento> ObterTodos() =>
            _orcamentoRepositorio.ObterTodos();

        public Orcamento Solicitar(OrcamentoCadastrarViewModel viewModel)
        {
            var orcamento = _mapeamentoEntidade.ConstruirCom(viewModel);

            _orcamentoRepositorio.Solicitar(orcamento);
            return orcamento;
        }
    }
}
