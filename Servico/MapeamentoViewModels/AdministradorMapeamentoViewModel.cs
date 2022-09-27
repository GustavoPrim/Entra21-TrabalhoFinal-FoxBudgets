using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoViewModels
{
    public class AdministradorMapeamentoViewModel : IAdministradorMapeamentoViewModel
    {
        public AdministradorEditarViewModel ConstruirCom(Administrador administrador)
        {
            return new AdministradorEditarViewModel
            {
                Id = administrador.Id,
                DataNascimento = administrador.DataNascimento,
                Endereco = administrador.Endereco,
                Email = administrador.Email,
                Telefone = administrador.Telefone,
				Login = administrador.Login,
				Senha = administrador.Senha,
				//Administradores = administrador.Administradores
			};
        }
    }
}