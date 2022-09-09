using Repositorio.Entidades;
using Servico.ViewModels.Administradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.MapeamentoEntidades
{
    public class AdministradorMapeamentoEntidade : IAdministradorMapeamentoEntidade
    {
        public void AtualizarCom(Administrador administrador, AdministradorEditarViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel)
        {
            return new Administrador
            {
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Email = viewModel.Email,
                DataNascimento = viewModel.DataNascimento,
                Cpf = viewModel.Cpf,
                Endereco = viewModel.Endereco
            };
        }
    }
}
