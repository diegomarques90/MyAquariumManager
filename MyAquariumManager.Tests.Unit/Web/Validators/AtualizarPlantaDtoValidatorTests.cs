using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc.Routing;
using MyAquariumManager.Application.Helpers;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using MyAquariumManager.Web.Validators.Planta;

namespace MyAquariumManager.Tests.Unit.Web.Validators
{
    public class AtualizarPlantaDtoValidatorTests
    {
        private readonly AtualizarPlantaDtoValidator _validator = new AtualizarPlantaDtoValidator();

        [Fact]
        public void SemFalhas_Quando_AtualizarPlantaDtoForValido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComAtualizacao()
                .ComTodosOsDadosValidos();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DeveTerFalha_Quando_IdInvalido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComIdInvalido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id).WithErrorMessage(BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO);
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeVazio()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComONomeInvalido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome).WithErrorMessage(BaseConstants.NOME_OBRIGATORIO);
        }

        [Fact]
        public void DeveTerFalha_Quando_Nome_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComNomeMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome).WithErrorMessage(BaseConstants.NOME_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeCientifico_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComNomeCientificoMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NomeCientifico).WithErrorMessage(BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_LocalAquisicao_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComLocalAquisicaoMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LocalAquisicao).WithErrorMessage(BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_DataAquisicao_ForFutura()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComDataAquisicaoFutura();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.DataAquisicao).WithErrorMessage(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDeTamanho_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDeCrescimento_ForInvalido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComTipoDeCrescimentoInvalido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TipoDeCrescimento).WithErrorMessage(BaseConstants.TIPO_CRESCIMENTO_INVALIDO);
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDeIluminacao_ForInvalido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComTipoDeIluminacaoInvalido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TipoDeIluminacao).WithErrorMessage(BaseConstants.TIPO_ILUMINACAO_INVALIDO);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDoPH_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFaixaDoPhMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FaixaDoPH).WithErrorMessage(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDeTemperatura_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFaixaDeTemperaturaMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FaixaDeTemperatura).WithErrorMessage(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_NivelDeCultivo_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComNivelDeCultivoMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NivelDeCutivo).WithErrorMessage(BaseConstants.NIVEL_CULTIVO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDePlantio_ForInvalido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComTipoDePlantioInvalido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TipoDePlantio).WithErrorMessage(BaseConstants.TIPO_PLANTIO_INVALIDO);
        }

        [Fact]
        public void DeveTerFalha_Quando_FormaDeReproducao_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFormaDeReproducaoMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FormaDeReproducao).WithErrorMessage(BaseConstants.FORMA_REPRODUCAO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_InformacoesAdicionais_ExcederCaracteres()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComInformacoesAdicionaisMaiorQueOPermitido();

            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.InformacoesAdicionais).WithErrorMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
