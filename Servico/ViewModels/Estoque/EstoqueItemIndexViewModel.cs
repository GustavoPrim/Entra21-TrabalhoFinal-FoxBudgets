﻿using Repositorio.Entidades;

namespace Servico.ViewModels.Estoque
{
    public class EstoqueItemIndexViewModel
    {
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public Material Material { get; set; }
        public int EstoqueMaterialId { get; set; }

    }
}
