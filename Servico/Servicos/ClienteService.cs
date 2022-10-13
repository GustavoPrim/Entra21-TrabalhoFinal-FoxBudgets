using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.Helpers;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteMapeamentoEntidade _mapeamento;

        public ClienteService(
            IClienteRepositorio clienteRepositorio,
            IClienteMapeamentoEntidade mapeamentoEntidade)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapeamento = mapeamentoEntidade;
        }
        public bool Apagar(int id) =>
            _clienteRepositorio.Apagar(id);

        public Cliente BuscarPorLogin(string login, string senha)
        {
            var cliente = _clienteRepositorio.BuscarPorLogin(login, senha);

            return cliente;
        }

        public Cliente Cadastrar(CadastrarUsuarioViewModel viewModel, string caminhoArquivo)
        {
            var caminho = SalvarArquivo(viewModel, caminhoArquivo);
            var cliente = _mapeamento.ConstruirCom(viewModel, caminho);
            _clienteRepositorio.Cadastrar(cliente);
            return cliente;
        }

        private string SalvarArquivo(CadastrarUsuarioViewModel viewModel, string caminhoArquivo, string? arquivoAntigo = "")
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

        public bool Editar(ClienteEditarViewModel viewModelEditar, string caminhoArquivo)
        {
            var cliente = _clienteRepositorio.ObterPorId(viewModelEditar.Id);

            if (cliente == null)
                return false;

            var caminho = SalvarArquivo(viewModelEditar, caminhoArquivo, cliente.CaminhoArquivo);

            _mapeamento.AtualizarCampos(cliente, viewModelEditar, caminho);

            _clienteRepositorio.Editar(cliente);
            return true;
        }
        public Cliente? ObterPorId(int id) =>
            _clienteRepositorio.ObterPorId(id);
        public IList<Cliente> ObterTodos() =>
            _clienteRepositorio.ObterTodos();

        public bool VerificarEmail(string email)
        {
            if (_clienteRepositorio.GetActiveUsers().Where(x => x.Email == email).ToList().Count > 0)
                return false;

            return true;
        }

        public Cliente AtualizarVerificarEmail(int id)
        {
            var user = _clienteRepositorio.ObterPorId(id);

            user.EmailConfirmado = true;

            _clienteRepositorio.Editar(user);

            return user;
        }

    }
}