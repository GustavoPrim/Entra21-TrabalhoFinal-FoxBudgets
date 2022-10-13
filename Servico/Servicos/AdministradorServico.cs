using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.Helpers;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IAdministradorMapeamentoEntidade _mapeamentoEntidade;
        private readonly OrcamentoContexto _contexto;
        

        public AdministradorServico(
            IAdministradorRepositorio administradorRepositorio,
            IAdministradorMapeamentoEntidade mapeamentoEntidade,
            OrcamentoContexto contexto)
        {
            _administradorRepositorio = administradorRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
            _contexto = contexto;
        }

        public bool Apagar(int id) =>
            _administradorRepositorio.Apagar(id);

        public Administrador Cadastrar(AdministradorCadastrarViewModel viewModel, string caminhoArquivo)
        {
            var caminho = SalvarArquivo(viewModel, caminhoArquivo);

            var administrador = _mapeamentoEntidade.ConstruirCom(viewModel, caminho);

            _administradorRepositorio.Cadastrar(administrador);
            return administrador;
        }

        public bool Editar(AdministradorEditarViewModel viewModel, string caminhoArquivos)
        {
            var administrador = _administradorRepositorio.ObterPorId(viewModel.Id);

            if (administrador == null)
                return false;

            var caminho = SalvarArquivo(viewModel, caminhoArquivos, administrador.Arquivo);

            _mapeamentoEntidade.AtualizarCom(administrador, viewModel, caminho);
            _administradorRepositorio.Editar(administrador);

            return true;
        }

        private string SalvarArquivo(AdministradorCadastrarViewModel viewModel, string caminhoArquivos, string? arquivoAntigo = "")
        {
            if(viewModel == null)
                return string.Empty;

            var pastaImagem = Path.Combine(caminhoArquivos, ArquivoHelper.ObterCaminhoPastas());

            if (!Directory.Exists(pastaImagem))
                Directory.CreateDirectory(pastaImagem);

            if (!string.IsNullOrEmpty(arquivoAntigo))
                ApagarArquivoAntigo(pastaImagem, arquivoAntigo);

            var informacaoArquivo = new FileInfo(viewModel.Arquivo.FileName);
            var nomeArquivo = Guid.NewGuid() + informacaoArquivo.Extension;

            var caminhoArquivo = Path.Combine(pastaImagem, nomeArquivo);

            using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                viewModel.Arquivo.CopyTo(stream);
                return nomeArquivo;
            }
        }

        private void ApagarArquivoAntigo(string pastaImagem, string arquivoAntigo)
        {
            var caminhoAntigo = Path.Join(pastaImagem, arquivoAntigo);

            if(File.Exists(caminhoAntigo))
                File.Delete(caminhoAntigo);
        }

        public Administrador? ObterPorId(int id) =>
            _administradorRepositorio.ObterPorId(id);

        public IList<Administrador> ObterTodos() =>
            _administradorRepositorio.ObterTodos();

        public Administrador BuscarPorLogin(string login, string senha)
        {
            var administrador = _administradorRepositorio.BuscarPorLogin(login, senha);

            return administrador;
        }
    }
}