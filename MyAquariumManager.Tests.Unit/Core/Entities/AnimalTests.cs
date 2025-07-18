﻿using MyAquariumManager.Core.Constants;
using MyAquariumManager.Tests.Unit.Builders;

namespace MyAquariumManager.Tests.Unit.Core.Entities
{
    public class AnimalTests
    {
        [Fact]
        public void CriarAnimal_DeveRetornarSucesso_QuandoAnimalEhValido()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos();
            
            var animal = builder.Build();

            // Act
            var (IsValid, _) = animal.Validate();

            // Assert
            Assert.True(IsValid, "O animal deve ser válido com todos os dados preenchidos corretamente.");
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoNomeEhNuloOuVazio()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando o nome é nulo ou vazio.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoNomeUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComNomeMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando o nome ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoNomeCientificoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComNomeCientificoMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando o nome científico ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoLocalAquisicaoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComLocalAquisicaoMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando o local de aquisição ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoEspecieUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComEspecieMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando a espécie ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.ESPECIE_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoFaixaDoPHUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDoPHMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando a faixa do pH ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoOrigemUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComOrigemMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando a origem ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.ORIGEM_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoComportamentoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComComportamentoMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando o comportamento ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.COMPORTAMENTO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoFaixaDeTamanhoUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDeTamanhoMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando a faixa de tamanho ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoFaixaDeTemperaturaUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComFaixaDeTemperaturaMaiorQueOPermitido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando a faixa de temperatura ultrapassa o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoInformacoesAdicionaisUltrapassaMaximoDeCaracteres()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComInformacoesAdicionaisMaiorQueOPermitido();

            var animal = builder.Build();
            
            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal deve ser inválido quando as informações adicionais ultrapassam o máximo de caracteres.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA, Errors, StringComparer.OrdinalIgnoreCase);
        }


        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoQuantidadeMinimaIdealIgualAZero()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComQuantidadeMinimaIdealIgualAZero();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando a quantidade mínima ideal é menor ou igual a zero.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.QUANTIDADE_MINIMA_IDEAL_MAIOR_QUE_ZERO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoLitragemMinimaIdealIgualAZero()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComLitragemMinimaIdealIgualAZero();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando a litragem mínima ideal é menor ou igual a zero.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoTipoDeAlimentacaoEhInvalido()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComTipoDeAlimentacaoInvalido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando o tipo de alimentação é inválido.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.TIPO_ALIMENTACAO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoTipoDeAguaEhInvalido()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComTipoDeAguaInvalido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando o tipo de alimentação é inválido.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.TIPO_AGUA_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarMultiplasFalhas_QuandoAnimalNaoEhValido()
        {
            // Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido()
                .ComLitragemMinimaIdealIgualAZero()
                .ComTipoDeAlimentacaoInvalido();

            var animal = builder.Build();

            // Act
            var (IsValid, Errors) = animal.Validate();

            // Assert
            Assert.False(IsValid, "O animal não deve ser válido quando possui múltiplos erros.");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count > 1, BaseConstants.DEVE_CONTER_MAIS_DE_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, Errors, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO, Errors, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(BaseConstants.TIPO_ALIMENTACAO_INVALIDO, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void CriarAnimal_DeveRetornarFalha_QuandoDataAquisicaoForFutura()
        {
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComDataAquisicaoFutura();

            var animal = builder.Build();

            var (IsValid, Errors) = animal.Validate();

            Assert.False(IsValid, "O animal não deve ser válido quando a data de aquisição é futura");
            Assert.NotEmpty(Errors);
            Assert.True(Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA, Errors, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void AtualizarAnimal_DeveRetornarSucesso_QuandoDataAtualizacaoForPreenchida()
        {
            //Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos();

            var animal = builder.Build();

            //Act
            animal.Atualizar();

            //Assert
            Assert.True(animal.DataAlteracao.HasValue, "A data de alteração deve ser preenchida após a atualização do animal.");
        }

        [Fact]
        public void InativarAnimal_DeveRetornarSucesso_QuandoPreencherTodosAsPropriedadesDoProcessoParaInativar()
        {
            //Arrange
            var builder = new AnimalBuilder()
                .ComTodosOsDadosValidos();

            var animal = builder.Build();

            //Act
            animal.Inativar(animal.UsuarioCriacao);

            //Assert
            Assert.True(animal.DataExclusao.HasValue, "A data de exclusão deve ser preenchida após a inativação do animal.");
            Assert.True(!animal.Ativo, "O animal deve estar desativado após a inativação.");
            Assert.NotNull(animal.UsuarioExclusao);
        }
    }
}
