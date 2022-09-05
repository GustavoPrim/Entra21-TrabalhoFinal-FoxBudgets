﻿using Microsoft.EntityFrameworkCore;
using Repositorio.Entidades;
using Repositorio.Mapeamentos;

namespace Repositorio.BancoDados
{
    public class ClienteContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteContexto(DbContextOptions<ClienteContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* 
            * Documentação: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
            * Necessário instalar a ferramenta do dotnet ef core
            *      dotnet tool install --global dotnet-ef
            * 1ª etapa - Criar a entidade Raca.cs
            * 2ª etapa - Criar o mapemanto da entidade para tabela RacaMapeamento.cs
            * 3ª etapa - Registrar o mapeamento no próprio Contexto
            * 4ª etapa - Gerar a migration
            *      dotnet ef migrations add AdicionarRacaTabela --project Repositorio --startup-project Entra21.CSharp.ClinicaVeterinaria.Aplicacao
            * 5ª etapa - A migration poderá ser aplicada de duas formas:
            *   - executar comando para aplicar a migration sem a
            *          necessidade de executar a aplicação
            *          dotnet ef database update --project Repositorio --startup-project Entra21.CSharp.ClinicaVeterinaria.Aplicacao
            *   - executar a aplicação irá aplicar a migration
            */

            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}