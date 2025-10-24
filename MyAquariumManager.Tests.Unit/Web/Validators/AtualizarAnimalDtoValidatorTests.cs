using FluentValidation.TestHelper;
using MyAquariumManager.Application.Mappers;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using MyAquariumManager.Web.Validators.Animal;

namespace MyAquariumManager.Tests.Unit.Web.Validators
{
    public class AtualizarAnimalDtoValidatorTests
    {
        private readonly AtualizarAnimalDtoValidator _validator = new AtualizarAnimalDtoValidator();

        [Fact]
        public void SemFalhas_Quando_AtualizarAnimalDtoForValido()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComAtualizacao()
                .ComTodosOsDadosValidos();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DeveTerFalha_Quando_IdInvalido()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComIdInvalido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorMessage(BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO);
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeVazio()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComONomeInvalido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage(BaseConstants.NOME_OBRIGATORIO);
        }

        [Fact]
        public void DeveTerFalha_Quando_Nome_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComNomeMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage(BaseConstants.NOME_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeCientifico_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComNomeCientificoMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NomeCientifico)
                .WithErrorMessage(BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_LocalAquisicao_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComLocalAquisicaoMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LocalAquisicao)
                .WithErrorMessage(BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_DataAquisicao_ForFutura()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComDataAquisicaoFutura();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.DataAquisicao)
                .WithErrorMessage(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA);
        }

        [Fact]
        public void DeveTerFalha_Quando_Especie_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComEspecieMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Especie)
                .WithErrorMessage(BaseConstants.ESPECIE_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDoPH_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFaixaDoPHMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FaixaDoPH)
                .WithErrorMessage(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_Origem_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComOrigemMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Origem)
                .WithErrorMessage(BaseConstants.ORIGEM_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_Comportamento_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComComportamentoMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Comportamento)
                .WithErrorMessage(BaseConstants.COMPORTAMENTO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_QuantidadeMinima_ForZero()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComQuantidadeMinimaIdealIgualAZero();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.QuantidadeMinima)
                .WithErrorMessage(BaseConstants.QUANTIDADE_MINIMA_IDEAL_MAIOR_QUE_ZERO);
        }

        [Fact]
        public void DeveTerFalha_Quando_LitragemMinima_ForZero()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComLitragemMinimaIdealIgualAZero();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LitragemMinima)
                .WithErrorMessage(BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO);
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoAlimentacao_ForInvalida()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComTipoDeAlimentacaoInvalido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TipoDeAlimentacao)
                .WithErrorMessage(BaseConstants.TIPO_ALIMENTACAO_INVALIDO);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDeTamanho_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFaixaDeTamanhoMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FaixaDeTamanho)
                .WithErrorMessage(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDeTemperatura_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComFaixaDeTemperaturaMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FaixaDeTemperatura)
                .WithErrorMessage(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA);
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDeAgua_ForInvalida()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComTipoDeAguaInvalido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TipoDeAgua)
                .WithErrorMessage(BaseConstants.TIPO_AGUA_INVALIDO);
        }


        [Fact]
        public void DeveTerFalha_Quando_InformacoesAdicionais_ExcederCaracteres()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComAtualizacao()
                .ComInformacoesAdicionaisMaiorQueOPermitido();

            var atualizarAnimalDto = AnimalHelper.ObterAtualizarAnimalDto(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(atualizarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.InformacoesAdicionais)
                .WithErrorMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
