using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Common;

namespace MyAquariumManager.Application.Interfaces.Services
{
    public interface IAnimalService
    {
        Task <Result<AnimalDto>> CadastrarAnimalAsync(CriarAnimalDto model);
        Task <Result<AnimalDto>> AtualizarAnimalAsync(AtualizarAnimalDto model);
        Task <Result> ExcluirAnimalAsync(Guid id, string usuarioExclusao);
        Task <Result<List<AnimalDto>>> ObterAnimaisAsync();
        Task <Result<AnimalDto>> ObterAnimalPorIdAsync(Guid id);
    }
}
