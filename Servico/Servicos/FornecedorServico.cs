using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.Helpers;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos
{
    public class FornecedorServico : IFornecedorServico
    {
        private readonly IFornecedorReposistorio _fornecedorReposistorio;
        private readonly IFornecedorMapeamentoEntidade _mapeamentoEntidade;

        public FornecedorServico(
            IFornecedorReposistorio fornecedorReposistorio,
            IFornecedorMapeamentoEntidade mapeamentoEntidade)
        {
            _fornecedorReposistorio = fornecedorReposistorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }

        public bool Apagar(int id) =>
            _fornecedorReposistorio.Apagar(id);

        public Fornecedor BuscarPorLogin(string login, string senha)
        {
            var fornecedor = _fornecedorReposistorio.BuscarPorLogin(login, senha);

            return fornecedor;
        }

        public Fornecedor CadastrarFornecedor(FornecedorCadastrarViewModel viewModel, string caminhoArquivo)
        {
            var caminho = SalvarArquivo(viewModel, caminhoArquivo);
            var fornecedor = _mapeamentoEntidade.ConstruirCom(viewModel, caminho);

            _fornecedorReposistorio.Cadastrar(fornecedor);

            return fornecedor;
        }

        private string SalvarArquivo(FornecedorCadastrarViewModel viewModel, string caminhoArquivo, string? arquivoAntigo = "")
        {
            if (viewModel.Arquivo == null)
                return string.Empty;

            var pastaImagem = Path.Combine(caminhoArquivo, ArquivoHelper.ObterCaminhoPastas());

            if (!Directory.Exists(pastaImagem))
                Directory.CreateDirectory(pastaImagem);

            if (!string.IsNullOrEmpty(arquivoAntigo))
                ApagarArquivoAntigo(pastaImagem, arquivoAntigo);

            var informacaoArquivo = new FileInfo(viewModel.Arquivo.FileName);
            var nomeArquivo = Guid.NewGuid() + informacaoArquivo.Extension;

            var caminhoDoArquivo = Path.Combine(pastaImagem, nomeArquivo);

            using (var stream = new FileStream(caminhoDoArquivo, FileMode.Create))
            {
                viewModel.Arquivo.CopyTo(stream);
                return nomeArquivo;
            }
        }

        private void ApagarArquivoAntigo(string pastaImagem, string arquivoAntigo)
        {
            var caminhoArquivoAntigo = Path.Join(pastaImagem, arquivoAntigo);

            if (File.Exists(caminhoArquivoAntigo))
                File.Delete(caminhoArquivoAntigo);
        }

        public bool Editar(FornecedorEditarViewModel viewModel, string caminhoArquivo)
        {
            var fornecedor = _fornecedorReposistorio.ObterPorId(viewModel.Id);

            if (fornecedor == null)
                return false;

            var caminho = SalvarArquivo(viewModel, caminhoArquivo, fornecedor.CaminhoArquivo);

            _mapeamentoEntidade.AtualizarCampos(fornecedor, viewModel, caminho);
            _fornecedorReposistorio.Editar(fornecedor);

            return true;
        }

        public Fornecedor? ObterPorId(int id) =>
            _fornecedorReposistorio.ObterPorId(id);

        public IList<Fornecedor> ObterTodos() =>
            _fornecedorReposistorio.ObterTodos();
    }
}