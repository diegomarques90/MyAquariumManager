using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAquariumManager.Tests.Unit.Core.Entities
{
    public class PlantaTests
    {
        [Fact]
        public void CriarPlanta_DeveRetornarSucesso_QuandoPlantaForValida()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos();

            var planta = builder.Build();

            // Act
            var (IsValid, _) = planta.Validate();

            // Assert
            Assert.True(IsValid, "A planta deve ser válido com todos os dados preenchidos corretamente.");
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoNomeEhNuloOuVazio()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o nome é nulo ou vazio.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoNomeUltrapassarMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComNomeMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o nome ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoNomeCientificoUltrapassarMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComNomeCientificoMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o nome científico ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoLocalAquisicaoUltrapassarMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComLocalAquisicaoMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o local de aquisição ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoDataAquisicaoForFutura()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComDataAquisicaoFutura();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando a data de aquisição for futura.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoFaixaDeTamanhoUltrapassarMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDeTamanhoMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando a faixa de tamanho ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoTipoDeCrescimentoEhInvalido()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComTipoDeCrescimentoInvalido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o tipo de crescimento for inválido.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.TIPO_CRESCIMENTO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoTipoDeIluminacaoEhInvalido()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComTipoDeIluminacaoInvalido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o tipo de iluminação for inválido.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.TIPO_CRESCIMENTO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoTipoDePlantioEHInvalido()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComTipoDePlantioInvalido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.True(IsValid, "A planta não deve ser válida quando o tipo de plantio for inválido.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.TIPO_PLANTIO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoFaixaDoPhUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDoPhMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando a faixa de pH ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoFaixaDeTemperaturaUltrapassaMaximoDeCaracteres()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoNivelDeCultivoUltrapassaMaximoDeCaracteres()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoFormaDeReproducaoUltrapassaMaximoDeCaracteres()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoInformacoesAdicionaisUltrapassaMaximoDeCaracteres()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void CriarPlanta_DeveRetornarMultiplasFalhas_QuandoPlantaNaoEhValida()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void AtualizarPlanta_DeveRetornarSucesso_QuandoDataAtualizacaoForPreenchida()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void InativarPlanta_DeveRetornarSucesso_QuandoPreencherTodosAsPropriedadesDoProcessoParaInativar()
        {
            // Arrange

            // Act

            // Assert

        }


        [Fact]
        public void Test()
        {
            // Arrange

            // Act

            // Assert

        }


    }
}
