﻿using System.ComponentModel.DataAnnotations;

namespace Repositorio.Entidades
{
    public class Administrador : Usuario
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string? Arquivo { get; set; }
    }
}