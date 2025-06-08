using AutoMapper;
using Moq;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Services;
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

            //Act

            //Assert
        }


        [Fact]
        public async Task CadastrarAnimal_DeveRetornarMultiplasFalhas_QuandoForInvalidoEmVariasCondicoes()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task AtualizarAnimal_DeveRetornarSucesso_QuandoAtualizacaoForValida()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task AtualizarAnimal_DeveRetornarFalha_QuandoAtualizacaoForInvalida()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ExcluirAnimal_DeveRetornarSucesso_QuandoExclusaoForValida()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async Task ExcluirAnimal_DeveRetornarFalha_QuandoExclusaoInvalida()
        {
            //Arrange

            //Act

            //Assert
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
