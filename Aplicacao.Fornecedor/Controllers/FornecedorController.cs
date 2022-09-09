﻿using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;
using Servico.ViewModels.Fornecedores;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Aplicacao.Fornecedor.Controllers
{
    [Route("fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorController(IFornecedorServico fornecedorServico)
        {
            _fornecedorServico = fornecedorServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var fornecedores = _fornecedorServico.ObterTodos().ToList();
            return Ok(fornecedores);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] FornecedorCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var fornecedor = _fornecedorServico.Cadastrar(viewModel);
            return Ok(fornecedor);
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromQuery] int id)
        {
            var fornecedor = _fornecedorServico.ObterPorId(id);

            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromBody] FornecedorEditarViewModel viewModel)
        {
            var alterar = _fornecedorServico.Editar(viewModel);

            if (!alterar)
                return NotFound();

            return Ok();
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var apagar = _fornecedorServico.Apagar(id);

            if (!apagar)
                return NotFound();

            return Ok();
        }
    }
}