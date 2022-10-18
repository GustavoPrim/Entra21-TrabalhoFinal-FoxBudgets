﻿using Microsoft.AspNetCore.Http;

namespace Repositorio.Entidades;

public class Cliente : Usuario
{
    public string? Cpf { get; set; }
    public string? Cnpj { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Guid Token { get; set; }
    public bool EmailConfirmado { get; set; }
    public DateTime DataInspiracaoToken { get; set; }


    public IList<Orcamento> Orcamentos { get; set; }
}