using AutoMapper;
using Moq;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Services;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Tests.Unit.Builders;
using MyAquariumManager.Tests.Unit.Fixtures;

namespace MyAquariumManager.Tests.Unit.Application.Services
{
    public class AnimalServiceTests : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAnimalRepository> _mockAnimalRepository;
        private readonly IAnimalService _animalService;

        public AnimalServiceTests(MapperFixture mapperFixture)
        {
            _mapper = mapperFixture.Mapper;
            _mockAnimalRepository = new Mock<IAnimalRepository>();
            _animalService = new AnimalService(_mapper, _mockAnimalRepository.Object);
        }

        [Fact]
        public async Task CadastrarAnimal_DeveRetornarSucesso_QuandoAnimalForValido()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());
            _mockAnimalRepository.Setup(x => x.AddAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _animalService.CadastrarAnimalAsync(criarAnimalDto);

            //Assert
            Assert.True(result.IsSuccess, "O cadastro do animal deve ser realizado quando for válido.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.IsType<AnimalDto>(result.Value);
            Assert.False(result.Value.Id == Guid.Empty, "O Id do animal não deve ser vazio após o cadastro.");
            Assert.NotEmpty(result.Value.DataCriacao.ToString());
            Assert.NotEmpty(result.Value.UsuarioCriacao);
            _mockAnimalRepository.Verify(r => r.AddAsync(It.IsAny<Animal>()), Times.Once, "O método AddAsync deve ser chamado uma vez.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task CadastrarAnimal_DeveRetornarFalha_QuandoForInvalido()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());
            _mockAnimalRepository.Setup(x => x.AddAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _animalService.CadastrarAnimalAsync(criarAnimalDto);

            //Assert
            Assert.True(result.IsFailure, "O cadastro do animal deve falhar quando for inválido.");
            Assert.NotEmpty(result.Errors);
            Assert.True(result.Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockAnimalRepository.Verify(r => r.AddAsync(It.IsAny<Animal>()), Times.Never, "O método AddAsync não deve ser chamado quando o animal é inválido.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando o animal é inválido.");
        }


        [Fact]
        public async Task CadastrarAnimal_DeveRetornarMultiplasFalhas_QuandoForInvalidoEmVariasCondicoes()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido()
                .ComDataAquisicaoFutura();

            var criarAnimalDto = _mapper.Map<CriarAnimalDto>(animalBuilder.Build());
            _mockAnimalRepository.Setup(x => x.AddAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _animalService.CadastrarAnimalAsync(criarAnimalDto);

            //Assert
            Assert.True(result.IsFailure, "O cadastro do animal deve falhar quando for inválido.");
            Assert.NotEmpty(result.Errors);
            Assert.True(result.Errors.Count > 1, BaseConstants.DEVE_CONTER_MAIS_DE_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, result.Errors, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockAnimalRepository.Verify(r => r.AddAsync(It.IsAny<Animal>()), Times.Never, "O método AddAsync não deve ser chamado quando o animal é inválido.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando o animal é inválido.");
        }

        [Fact]
        public async Task AtualizarAnimal_DeveRetornarSucesso_QuandoAtualizacaoForValida()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos();
                        
            var atualizarAnimalDto = _mapper.Map<AtualizarAnimalDto>(animalBuilder.Build());
            atualizarAnimalDto.LocalAquisicao = "Loja de Aquarismo Atualizada";
            atualizarAnimalDto.UsuarioAlteracao = "usertests@myaquariummanager.com";
            
            _mockAnimalRepository.Setup(x => x.UpdateAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var resultUpdate = await _animalService.AtualizarAnimalAsync(atualizarAnimalDto);

            //Assert
            Assert.True(resultUpdate.IsSuccess, "A atualização do animal deve ser realizada quando for válida.");
            Assert.Empty(resultUpdate.Errors);
            Assert.NotNull(resultUpdate.Value);
            Assert.Equal(atualizarAnimalDto.LocalAquisicao, resultUpdate.Value.LocalAquisicao, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(resultUpdate.Value.DataAlteracao);
            Assert.NotNull(resultUpdate.Value.UsuarioAlteracao);
            _mockAnimalRepository.Verify(r => r.UpdateAsync(It.IsAny<Animal>()), Times.Once, "O método UpdateAsync deve ser chamado uma vez.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task AtualizarAnimal_DeveRetornarFalha_QuandoAtualizacaoForInvalida()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos()
                .ComLitragemMinimaIdealIgualAZero();

            var atualizarAnimalDto = _mapper.Map<AtualizarAnimalDto>(animalBuilder.Build());
            atualizarAnimalDto.LocalAquisicao = "Loja de Aquarismo Atualizada";
            atualizarAnimalDto.UsuarioAlteracao = BaseConstants.USER_UNIT_TESTS;

            _mockAnimalRepository.Setup(x => x.UpdateAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var resultUpdate = await _animalService.AtualizarAnimalAsync(atualizarAnimalDto);

            //Assert
            Assert.True(resultUpdate.IsFailure, "A atualização do animal não deve ser realizada quando for inválida.");
            Assert.NotEmpty(resultUpdate.Errors);
            Assert.Contains(BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO, resultUpdate.Errors, StringComparer.OrdinalIgnoreCase);
            _mockAnimalRepository.Verify(r => r.UpdateAsync(It.IsAny<Animal>()), Times.Never, "O método UpdateAsync não deve ser chamado quando a atualização for inválida.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando a atualização for inválida.");
        }

        [Fact]
        public async Task ExcluirAnimal_DeveRetornarSucesso_QuandoExclusaoForValida()
        {
            //Arrange
            var animalBuilder = new AnimalBuilder()
                .ComTodosOsDadosValidos();

            var animal = animalBuilder.Build();
            _mockAnimalRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(animal);
            _mockAnimalRepository.Setup(s => s.UpdateAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(s => s.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _animalService.ExcluirAnimalAsync(animal.Id, animal.UsuarioCriacao);

            //Assert
            Assert.True(result.IsSuccess, "A exclusão do animal deve ser realizada quando for válida.");
            _mockAnimalRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
            _mockAnimalRepository.Verify(r => r.UpdateAsync(It.IsAny<Animal>()), Times.Once, "O método UpdateAsync deve ser chamado uma vez.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ExcluirAnimal_DeveRetornarFalha_QuandoExclusaoInvalida()
        {
            //Arrange
            _mockAnimalRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()));
            _mockAnimalRepository.Setup(s => s.UpdateAsync(It.IsAny<Animal>())).Returns(Task.CompletedTask);
            _mockAnimalRepository.Setup(s => s.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _animalService.ExcluirAnimalAsync(Guid.NewGuid(), BaseConstants.USER_UNIT_TESTS);

            //Assert
            Assert.True(result.IsFailure, "A exclusão do animal não deve ser realizada quando for inválida.");
            Assert.True(result.Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.ANIMAL_NAO_EXISTE_OU_JA_FOI_EXCLUIDO, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockAnimalRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
            _mockAnimalRepository.Verify(r => r.UpdateAsync(It.IsAny<Animal>()), Times.Never, "O método UpdateAsync não deve ser chamado quando a exclusão for inválida.");
            _mockAnimalRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando a exclusão for inválida.");
        }

        [Fact]
        public async Task ObterTodosAnimais_DeveRetornarSucesso_QuandoSolicitacaoForValida()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ObterTodosAnimais_DeveRetornarFalha_QuandoNaoPossuirAnimais()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ObterAnimalPorId_DeveRetornarSucesso_QuandoForValido()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ObterAnimalPorId_DeveRetornarFalha_QuandoNaoForEncontrado()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ObterAnimalPorId_DeveRetornarFalha_QuandoIdForInvalido()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
