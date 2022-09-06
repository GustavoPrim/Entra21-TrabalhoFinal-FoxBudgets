﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Cnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("cnpj");

            builder.Property(x => x.Endereco)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.DataFundacao)
                .HasColumnType("DATETIME2")
                .HasMaxLength(8)
                .IsRequired()
                .HasColumnName("dataFundacao");

            builder.Property(x => x.Categoria)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("categoria");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(25)
                .IsRequired()
                .HasColumnName("email");
        }
    }
}
