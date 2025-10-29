using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Assert.Contains(BaseConstants.TIPO_ILUMINACAO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
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
            Assert.False(IsValid, "A planta não deve ser válida quando o tipo de plantio for inválido.");
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
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDeTemperaturaMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando a faixa de temperatura ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoNivelDeCultivoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComNivelDeCultivoMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando o nível de cultivo ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NIVEL_CULTIVO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoFormaDeReproducaoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComFormaDeReproducaoMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando a forma de reprodução ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FORMA_REPRODUCAO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarFalha_QuandoInformacoesAdicionaisUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComInformacoesAdicionaisMaiorQueOPermitido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando as informações adicionais ultrapassar a quantidade máxima de carecteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarPlanta_DeveRetornarMultiplasFalhas_QuandoPlantaNaoEhValida()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido()
                .ComTipoDePlantioInvalido();

            var planta = builder.Build();

            // Act
            var (IsValid, Errors) = planta.Validate();

            // Assert
            Assert.False(IsValid, "A planta não deve ser válida quando possui múltiplos erros.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count > 1, BaseConstants.DEVE_CONTER_MAIS_DE_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, Errors, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(BaseConstants.TIPO_PLANTIO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void AtualizarPlanta_DeveRetornarSucesso_QuandoDataAtualizacaoForPreenchida()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComUsuarioAlteracao();

            var planta = builder.Build();

            // Act && Assert
            Assert.True(planta.DataAlteracao.HasValue, "A data de alteração deve ser preenchida ao atualizar a planta.");
        }

        [Fact]
        public void InativarPlanta_DeveRetornarSucesso_QuandoPreencherTodosAsPropriedadesDoProcessoParaInativar()
        {
            // Arrange
            var builder = new PlantaBuilder()
                .ComTodosOsDadosValidos();

            var planta = builder.Build();

            // Act
            planta.Inativar(planta.UsuarioCriacao);

            // Assert
            Assert.True(planta.DataExclusao.HasValue, "A data de exclusão deve ser preenchida ao inativar a planta.");
            Assert.True(!planta.Ativo, "A planta deve estar inativa após a inativação.");
            Assert.NotNull(planta.UsuarioExclusao);
        }


        //[Fact]
        //public void Test()
        //{
        //    // Arrange

        //    // Act

        //    // Assert

        //}
    }
}
