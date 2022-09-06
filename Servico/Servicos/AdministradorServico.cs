using Aplicacao.Administradores;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    internal class AdministradorServico : IAdministradorServico
    {

        private readonly IAdministradorRepositorio _administradorRepositorio;
        private readonly IAdministradorMapeamentoEntidade _mapeamentoEntidade;

        public AdministradorServico(
            IAdministradorRepositorio administradorRepositorio,
            IAdministradorMapeamentoEntidade mapeamentoEntidade)
        {
            _administradorRepositorio = administradorRepositorio;
            _mapeamentoEntidade = mapeamentoEntidade;
        }

        public bool Apagar(int id) =>
            _administradorRepositorio.Apagar(id);


        public Administrador Cadastrar(AdministradorCadastrarViewModel viewModel)
        {
            var administrador = _mapeamentoEntidade.ConstruirCom(viewModel);

            _administradorRepositorio.Cadastrar(administrador);

            return administrador;
        }

        private string SalvarArquivo(AdministradorCadastrarViewModel viewModel, string caminhoArquivos)
        {
            if (viewModel.Arquivo == null)
                return string.Empty;

            var path = Path.Combine(caminhoArquivos, PastaImagens);

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var informacaoDoArquivo = new FileInfo(viewModel.Arquivo.FileName);
            var nomeArquivo = Guid.NewGuid() + informacaoDoArquivo.Extension;

            string caminhoArquivo = Path.Combine(path, nomeArquivo);

            using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                viewModel.Arquivo.CopyTo(stream);

                return nomeArquivo;
            }
        }

        public void Editar(AdministradorCadastrarViewModel administradorEditarViewModel)
        {
            throw new NotImplementedException();
        }

        public Administrador? ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrador> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Administrador> ObterTodosSelect2()
        {
            throw new NotImplementedException();
        }
    }
}
