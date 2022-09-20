﻿using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Materiais
{
    public class MateriaisCadastrarViewModel
    {
        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "Informe nome do Material")]
        [MinLength(3, ErrorMessage = "{0} deve conter pelo menos {1} caracteres")]
        [MaxLength(20, ErrorMessage = "{0} deve conter apenas {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Código Sku")]
        [Required(ErrorMessage = "Informe o código do Material")]
        [MinLength(5, ErrorMessage = "{0} deve conter pelo menos {1} caracteres")]
        [MaxLength(16, ErrorMessage = "{0} deve conter apenas {1} caracteres")]
        public string Sku { get; set; }

        [Display(Name = "Possui Data de Validade?")]
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe uma descrição sobre o material")]
        [MinLength(8, ErrorMessage = "{0} a descrição deve conter pelo menos{1} caracteres")]
        [MaxLength(200, ErrorMessage = "{0} a descrição deve conter apenas {1} caracteres")]
        public string Descricao { get; set; }
    }
}