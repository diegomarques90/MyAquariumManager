using AutoMapper;
using FluentValidation.TestHelper;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;
using MyAquariumManager.Tests.Unit.Fixtures;
using MyAquariumManager.Web.Validators.Animal;

namespace MyAquariumManager.Tests.Unit.Web.Validators
{
    public class CriarAnimalDtoValidatorTests(MapperFixture mapperFixture) : IClassFixture<MapperFixture>
    {
        private readonly CriarAnimalDtoValidator _validator = new CriarAnimalDtoValidator();
        private readonly IMapper _mapper = mapperFixture.Mapper;

        [Fact]
        public void SemFalhas_Quando_CriarAnimalDtoForValido()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeVazio()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComNomeMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComNomeCientificoMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComLocalAquisicaoMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComDataAquisicaoFutura();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComEspecieMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComFaixaDoPHMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComOrigemMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComComportamentoMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComQuantidadeMinimaIdealIgualAZero();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComLitragemMinimaIdealIgualAZero();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComTipoDeAlimentacaoInvalido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComFaixaDeTamanhoMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComFaixaDeTemperaturaMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComTipoDeAguaInvalido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

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
                .ComInformacoesAdicionaisMaiorQueOPermitido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());

            //Act
            var result = _validator.TestValidate(criarAnimalDto);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.InformacoesAdicionais)
                .WithErrorMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
