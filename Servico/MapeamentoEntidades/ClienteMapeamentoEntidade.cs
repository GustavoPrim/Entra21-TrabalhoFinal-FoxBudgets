//using Repositorio.Entidades;
//using Servico.ViewModels.Clientes;

//namespace Servico.MapeamentoEntidades
//{
//    public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
//    {
//        public void AtualizarCom(Cliente cliente, ClienteEditarViewModel clienteEditarViewModel, string caminho)
//        {
//            cliente.Cpf =  clienteEditarViewModel.Cpf;
//            cliente.Cnpj = clienteEditarViewModel.Cnpj;
//            cliente.DataNascimento = clienteEditarViewModel.DataNascimento;
//            cliente.Endereco = clienteEditarViewModel.Endereco;
//            cliente.Email = clienteEditarViewModel.Email;
//            cliente.Telefone = clienteEditarViewModel.Telefone;
//            cliente.Crea = clienteEditarViewModel.Crea;
//        }

//        public Cliente ConstruirCom(ClienteCadastrarViewModel viewModel, string caminho)
//        {
//            return new Cliente
//            {
//                Cpf = viewModel.Cpf,
//                Cnpj = viewModel.Cnpj,
//                DataNascimento = viewModel.DataNascimento,
//                Endereco = viewModel.Endereco,
//                Email = viewModel.Email,
//                Telefone = viewModel.Telefone,
//                Crea = viewModel.Crea
//            };
//        }
//    }
//}