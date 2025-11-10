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

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_IdInvalido()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeVazio()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_Nome_ExcederCaracteres()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_NomeCientifico_ExcederCaracteres()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_LocalAquisicao_ExcederCaracteres()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_DataAquisicao_ForFutura()
        {
            //Arrange

            //Act

            //Assert
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
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDeIluminacao_ForInvalido()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDoPH_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_FaixaDeTemperatura_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_NivelDeCultivo_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_TipoDePlantio_ForInvalido()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_FormaDeReproducao_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeveTerFalha_Quando_InformacoesAdicionais_ExcederCaracteres()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
