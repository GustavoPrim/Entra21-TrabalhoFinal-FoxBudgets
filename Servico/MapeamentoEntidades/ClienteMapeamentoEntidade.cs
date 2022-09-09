using Repositorio.Entidades;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.MapeamentoEntidades
{
    public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
    {
        public Cliente ConstruirCom(ClienteCadastrarViewModel viewModel, string caminho)
        {
            return new Cliente
            {
                Cpf = viewModel.Cpf,
                Cnpj = viewModel.Cnpj,
                DataNascimento = viewModel.DataNascimento,
                Endereco = viewModel.Endereco,
                Email = viewModel.Email,
                Telefone = viewModel.Telefone,
                Crea = viewModel.Crea,


            };
        }
    }
}