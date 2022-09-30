namespace Servico.Email
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
