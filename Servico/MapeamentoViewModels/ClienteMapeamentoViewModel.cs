using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoViewModels
{
    public class ClienteMapeamentoViewModel : IClienteMapeamentoViewModel
    {
        public ClienteEditarViewModel ConstruirCom(ClienteEditarViewModel cliente)
        {
            return new ClienteEditarViewModel
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Cnpj = cliente.Cnpj,
                DataNascimento = cliente.DataNascimento,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Login = cliente.Login,
                Senha = cliente.Senha
            };
        }
    }
}