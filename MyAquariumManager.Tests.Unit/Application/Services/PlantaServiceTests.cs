using Moq;
using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Application.Helpers;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Services;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Tests.Unit.Builders;
using System.Numerics;

namespace MyAquariumManager.Tests.Unit.Application.Services
{
    public class PlantaServiceTests
    {
        private readonly Mock<IPlantaRepository> _mockPlantaRepository;
        private readonly IPlantaService _plantaService;

        public PlantaServiceTests()
        {
            _mockPlantaRepository = new Mock<IPlantaRepository>();
            _plantaService = new PlantaService(_mockPlantaRepository.Object);
        }

        [Fact]
        public async Task CadastrarPlanta_DeveRetornarSucesso_QuandoPlantaForValida()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos();

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());
            _mockPlantaRepository.Setup(x => x.AddAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.CadastrarPlantaAsync(criarPlantaDto);

            //Assert
            Assert.True(result.IsSuccess, "O cadastro da planta deve ser realizado quando for válido.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.IsType<PlantaDto>(result.Value);
            Assert.False(result.Value.Id == Guid.Empty, "O Id da planta cadastrada não deve ser vazio.");
            Assert.NotEmpty(result.Value.DataCriacao.ToString());
            Assert.NotEmpty(result.Value.UsuarioCriacao);
            _mockPlantaRepository.Verify(r => r.AddAsync(It.IsAny<Planta>()), Times.Once, "O método AddAsync deve ser chamado uma vez.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task CadastrarPlanta_DeveRetornarFalha_QuandoForInvalido()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido();

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());
            _mockPlantaRepository.Setup(x => x.AddAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.CadastrarPlantaAsync(criarPlantaDto);

            //Assert
            Assert.True(result.IsFailure, "O cadastro da planta deve falhar quando for inválido.");
            Assert.NotEmpty(result.Errors);
            Assert.True(result.Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.AddAsync(It.IsAny<Planta>()), Times.Never, "O método AddAsync não deve ser chamado.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado.");
        }

        [Fact]
        public async Task CadastrarPlanta_DeveRetornarMultiplasFalhas_QuandoForInvalidoEmVariasCondicoes()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComONomeInvalido()
                .ComDataAquisicaoFutura();

            var criarPlantaDto = PlantaHelper.ObterCriarPlantaDto(plantaBuilder.Build());
            _mockPlantaRepository.Setup(x => x.AddAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.CadastrarPlantaAsync(criarPlantaDto);

            //Assert
            Assert.True(result.IsFailure, "O cadastro da planta deve falhar quando for inválido.");
            Assert.NotEmpty(result.Errors);
            Assert.True(result.Errors.Count > 1, BaseConstants.DEVE_CONTER_MAIS_DE_UM_ERRO);
            Assert.Contains(BaseConstants.NOME_OBRIGATORIO, result.Errors, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.AddAsync(It.IsAny<Planta>()), Times.Never, "O método AddAsync não deve ser chamado.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado.");
        }

        [Fact]
        public async Task AtualizarPlanta_DeveRetornarSucesso_QuandoAtualizacaoForValida()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComUsuarioAlteracao();

            var planta = plantaBuilder.Build();
            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(planta);
            atualizarPlantaDto.LocalAquisicao = "Loja de Aquarismo Atualizada";

            _mockPlantaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(planta);
            _mockPlantaRepository.Setup(x => x.UpdateAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.AtualizarPlantaAsync(atualizarPlantaDto);

            //Assert
            Assert.True(result.IsSuccess, "A atualização da planta deve ser realizada quando for válida.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.Equal(atualizarPlantaDto.LocalAquisicao, result.Value.LocalAquisicao, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(result.Value.DataAlteracao);
            Assert.NotNull(result.Value.UsuarioAlteracao);
            _mockPlantaRepository.Verify(r => r.UpdateAsync(It.IsAny<Planta>()), Times.Once, "O método UpdateAsync deve ser chamado uma vez.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task AtualizarPlanta_DeveRetornarFalha_QuandoAtualizacaoForInvalida()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .ComUsuarioAlteracao()
                .ComFaixaDeTamanhoMaiorQueOPermitido();

            var planta = plantaBuilder.Build();
            var atualizarPlantaDto = PlantaHelper.ObterAtualizarPlantaDto(planta);
            atualizarPlantaDto.LocalAquisicao = "Loja de Aquarismo Atualizada";

            _mockPlantaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(planta);
            _mockPlantaRepository.Setup(x => x.UpdateAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.AtualizarPlantaAsync(atualizarPlantaDto);

            //Assert
            Assert.True(result.IsFailure, "A atualização da planta não deve ser realizada quando for inválida.");
            Assert.NotEmpty(result.Errors);
            Assert.Contains(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.UpdateAsync(It.IsAny<Planta>()), Times.Never, "O método UpdateAsync não deve ser chamado quando a atualização for inválida.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando a atualização for inválida.");
        }

        [Fact]
        public async Task ExcluirPlanta_DeveRetornarSucesso_QuandoExclusaoForValida()
        {
            //Arrange
            var plantaBuilder = new PlantaBuilder()
                .ComTodosOsDadosValidos();

            var planta = plantaBuilder.Build();
            _mockPlantaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(planta);
            _mockPlantaRepository.Setup(x => x.UpdateAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            //Act
            var result = await _plantaService.ExcluirPlantaAsync(planta.Id, planta.UsuarioCriacao);

            //Assert
            Assert.True(result.IsSuccess, "A exclusão da planta deve ser realizada quando for válida.");
            _mockPlantaRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
            _mockPlantaRepository.Verify(r => r.UpdateAsync(It.IsAny<Planta>()), Times.Once, "O método UpdateAsync deve ser chamado uma vez.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "O método SaveChangesAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ExcluirPlanta_DeveRetornarFalha_QuandoExclusaoForInvalida()
        {
            //Arrange
            _mockPlantaRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()));
            _mockPlantaRepository.Setup(s => s.UpdateAsync(It.IsAny<Planta>())).Returns(Task.CompletedTask);
            _mockPlantaRepository.Setup(s => s.SaveChangesAsync()).Returns(Task.CompletedTask);


            //Act
            var result = await _plantaService.ExcluirPlantaAsync(Guid.NewGuid(), BaseConstants.USER_UNIT_TESTS);

            //Assert
            Assert.True(result.IsFailure, "A exclusão da planta não deve ser realizada quando for inválida.");
            Assert.True(result.Errors.Count == 1, BaseConstants.DEVE_CONTER_APENAS_UM_ERRO);
            Assert.Contains(BaseConstants.PLANTA_NAO_EXISTE_OU_JA_FOI_EXCLUIDA, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
            _mockPlantaRepository.Verify(r => r.UpdateAsync(It.IsAny<Planta>()), Times.Never, "O método UpdateAsync não deve ser chamado quando a exclusão for inválida.");
            _mockPlantaRepository.Verify(r => r.SaveChangesAsync(), Times.Never, "O método SaveChangesAsync não deve ser chamado quando a exclusão for inválida.");
        }

        [Fact]
        public async Task ObterTodasAsPlantas_DeveRetornarSucesso_QuandoSolicitacaoForValida()
        {
            //Arrange
            var plantas = new List<Planta>
            {
                new PlantaBuilder().ComTodosOsDadosValidos().Build(),
                new PlantaBuilder().ComTodosOsDadosValidos().Build(),
                new PlantaBuilder().ComTodosOsDadosValidos().Build()
            };

            _mockPlantaRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(plantas);

            //Act
            var result = await _plantaService.ObterPlantasAsync();

            //Assert
            Assert.True(result.IsSuccess, "A obtenção de todas as plantas deve ser realizada com sucesso.");
            Assert.NotEmpty(result.Value);
            Assert.IsType<List<PlantaDto>>(result.Value);
            Assert.Equal(plantas.Count, result.Value.Count);
            _mockPlantaRepository.Verify(r => r.GetAllAsync(), Times.Once, "O método GetAllAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ObterTodasAsPlantas_DeveRetornarListaVazia_QuandoNaoPossuirPlantasCadastradas()
        {
            //Arrange
            var plantas = new List<Planta>();

            _mockPlantaRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(plantas);

            //Act
            var result = await _plantaService.ObterPlantasAsync();

            //Assert
            Assert.True(result.IsSuccess, "A obtenção de todas as plantas deve ser realizada com sucesso.");
            Assert.True(result.Value.Count == 0, "A lista de plantas deve estar vazia quando não houver plantas cadastradas.");
            Assert.IsType<List<PlantaDto>>(result.Value);
            Assert.Empty(result.Value);
            _mockPlantaRepository.Verify(r => r.GetAllAsync(), Times.Once, "O método GetAllAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ObterPlantaPorId_DeveRetornarSucesso_QuandoForValida()
        {
            //Arrange
            var planta = new PlantaBuilder()
                .ComTodosOsDadosValidos()
                .Build();

            _mockPlantaRepository.Setup(x => x.GetByIdAsync(planta.Id)).ReturnsAsync(planta);

            //Act
            var result = await _plantaService.ObterPlantaPorIdAsync(planta.Id);

            //Assert
            Assert.True(result.IsSuccess, "A obtenção da planta por Id deve ser realizada com sucesso.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.IsType<PlantaDto>(result.Value);
            Assert.Equal(planta.Id, result.Value.Id);
            _mockPlantaRepository.Verify(r => r.GetByIdAsync(planta.Id), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ObterPlantaPorId_DeveRetornarFalha_QuandoNaoForEncontrada()
        {
            //Arrange
            _mockPlantaRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Planta)null);

            //Act
            var result = await _plantaService.ObterPlantaPorIdAsync(Guid.NewGuid());

            //Assert
            Assert.True(result.IsFailure, "A obtenção da planta por Id deve falhar quando não for encontrada.");
            Assert.NotEmpty(result.Errors);
            Assert.Contains(BaseConstants.PLANTA_NAO_EXISTE_OU_JA_FOI_EXCLUIDA, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Once, "O método GetByIdAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ObterPlantaPorId_DeveRetornarFalha_QuandoForInvalido()
        {
            //Arrange
            _mockPlantaRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()));

            //Act
            var result = await _plantaService.ObterPlantaPorIdAsync(Guid.Empty);

            //Assert
            Assert.True(result.IsFailure, "A obtenção da planta por Id deve falhar quando o Id for inválido.");
            Assert.NotEmpty(result.Errors);
            Assert.Contains(BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO, result.Errors, StringComparer.OrdinalIgnoreCase);
            _mockPlantaRepository.Verify(r => r.GetByIdAsync(It.IsAny<Guid>()), Times.Never, "O método GetByIdAsync não deve ser chamado quando o Id for inválido.");
        }

        [Fact]
        public async Task ObterTablePlantas_DeveRetornarSucesso_QuandoSolicitacaoForValida()
        {
            //Arrange
            var plantas = new List<Planta>
            {
                new PlantaBuilder().ComTodosOsDadosValidos().Build(),
                new PlantaBuilder().ComTodosOsDadosValidos().Build(),
                new PlantaBuilder().ComTodosOsDadosValidos().Build()
            };

            var listaTablePlantasDto = PlantaHelper.ObterListaDeTabelaPlantaDto(plantas);

            var dataTable = new DataTableResult<TablePlantaDto>
            {
                Dados = listaTablePlantasDto,
                TotalFiltrado = listaTablePlantasDto.Count,
                TotalGeral = plantas.Count,
            };

            var dataTableFilters = new DataTableFilters("", 0, 20, "1", "desc");

            _mockPlantaRepository.Setup(s => s.ObterDataTableAsync(It.IsAny<DataTableFilters>())).ReturnsAsync(plantas);

            //Act
            var result = await _plantaService.CarregarTablePlantasAsync(dataTableFilters);

            //Assert
            Assert.True(result.IsSuccess, "A obtenção da tabela de plantas deve ser realizada com sucesso.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.IsType<DataTableResult<TablePlantaDto>>(result.Value);
            Assert.Equal(dataTable.TotalGeral, result.Value.TotalGeral);
            _mockPlantaRepository.Verify(r => r.ObterDataTableAsync(It.IsAny<DataTableFilters>()), Times.Once, "O método ObterDataTableAsync deve ser chamado uma vez.");
        }

        [Fact]
        public async Task ObterTablePlantas_DeveRetornarListaVazia_QuandoNaoPossuirPlantasCadastrados()
        {
            //Arrange
            var plantas = new List<Planta>();

            var listaTablePlantasDto = PlantaHelper.ObterListaDeTabelaPlantaDto(plantas);

            var dataTable = new DataTableResult<TablePlantaDto>
            {
                Dados = listaTablePlantasDto,
                TotalFiltrado = listaTablePlantasDto.Count,
                TotalGeral = plantas.Count,
            };

            var dataTableFilters = new DataTableFilters("", 0, 20, "1", "desc");

            _mockPlantaRepository.Setup(s => s.ObterDataTableAsync(It.IsAny<DataTableFilters>())).ReturnsAsync(plantas);

            //Act
            var result = await _plantaService.CarregarTablePlantasAsync(dataTableFilters);

            //Assert
            Assert.True(result.IsSuccess, "A obtenção da tabela de plantas deve ser realizada com sucesso.");
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
            Assert.IsType<DataTableResult<TablePlantaDto>>(result.Value);
            Assert.Equal(0, result.Value.TotalGeral);
            _mockPlantaRepository.Verify(r => r.ObterDataTableAsync(It.IsAny<DataTableFilters>()), Times.Once, "O método ObterDataTableAsync deve ser chamado uma vez.");
        }
    }
}
