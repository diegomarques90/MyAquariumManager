using FluentValidation.TestHelper;
using MyAquariumManager.Application.Helpers;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using MyAquariumManager.Web.Validators.Planta;

namespace MyAquariumManager.Tests.Unit.Web.Validators.Planta
{
    public class CriarPlantaDtoValidatorTests
    {
        private readonly CriarPlantaDtoValidator _validator = new CriarPlantaDtoValidator();

        [Fact]
        public void SemFalhas_Quando_AtualizarPlantaDtoForValido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComAtualizacao()
                .ComTodosOsDadosValidos();

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeVazio()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComONomeInvalido();

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

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

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarPlantaDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.InformacoesAdicionais).WithErrorMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
