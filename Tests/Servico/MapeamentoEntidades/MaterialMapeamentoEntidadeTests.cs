using FluentAssertions;
using Repositorio.Entidades;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.Materiais;
using Xunit;

namespace Tests.Servico.MapeamentoEntidades
{
    public class MaterialMapeamentoEntidadeTests
    {
        private readonly IMaterialMapeamentoEntidade _materialMapeamentoEntidade;

        public MaterialMapeamentoEntidadeTests()
        {
            _materialMapeamentoEntidade = new MaterialMapeamentoEntidade();
        }

        [Fact]
        public void Test_construirCom()
        {
            //Arrange
            var viewModel = new MateriaisCadastrarViewModel
            {
                Nome = "Paulo",
                DataValidade = Convert.ToDateTime("2002/02/02"),
                Descricao = "aço de metal 2kg",
                Sku = "AKSDKWKAKSDKWAK",
            };
            //Act
            var estoque = _materialMapeamentoEntidade.ConstruirCom(viewModel);

            //Assert
            estoque.Nome.Should().Be(viewModel.Nome);
            estoque.DataValidade.Should().Be(viewModel.DataValidade);
            estoque.Descricao.Should().Be(viewModel.Descricao);
            estoque.Sku.Should().Be(viewModel.Sku);
        }

        [Fact]
        public void Test_AtualizarCom()
        {
            //Arrange
            var material = new Material
            {
                Nome = "Pedrinho",
                Descricao = "3kg de cimento",
                DataValidade = Convert.ToDateTime("2005/01/02"),
                Sku = "aksdkskakskdwkaskdkwas",
                PossuiDataValidade = false
            };
            var materialParaEditar = new MateriaisEditarViewModel
            {
                Nome = "Paulo",
                Descricao = "20kg de cimento",
                DataValidade = Convert.ToDateTime("2014/01/02"),
                Sku = "aksdkwaksd",
                PossuiDataValidade = true
            };
            //Act
            _materialMapeamentoEntidade.AtualizarCom(material, materialParaEditar);

            //Assert
            material.Nome.Should().Be(materialParaEditar.Nome);
            material.Descricao.Should().Be(materialParaEditar.Descricao);
            material.DataValidade.Should().Be(materialParaEditar.DataValidade);
            material.Sku.Should().Be(materialParaEditar.Sku);
        }

    }
}
