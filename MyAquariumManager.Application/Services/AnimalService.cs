using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Enums;
using MyAquariumManager.Core.Interfaces.Repositories;

namespace MyAquariumManager.Application.Services
{
    public class AnimalService(IMapper mapper, IAnimalRepository animalRepository) : IAnimalService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAnimalRepository _animalRepository = animalRepository;

        public Task<Result<AnimalDto>> AtualizarAnimalAsync(AtualizarAnimalDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AnimalDto>> CadastrarAnimalAsync(CriarAnimalDto model)
        {
            var animal = _mapper.Map<Animal>(model);

            var (isValid, errors) = animal.Validate();

            if (!isValid)
                return Result<AnimalDto>.Failure(errors);

            try
            {
                await _animalRepository.AddAsync(animal);
                await _animalRepository.SaveChangesAsync();

                var animalDto = _mapper.Map<AnimalDto>(animal);
                return Result<AnimalDto>.Success(animalDto, HttpCode.Created);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados no cadastro de animais: {dbEx.Message}");
                return Result<AnimalDto>.Failure(["Erro de persistência ao cadastrar o animal. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar animais: {ex.Message}");
                return Result<AnimalDto>.Failure([$"Ocorreu um erro inesperado ao cadastrar o animal: {ex.Message}"]);
            }
        }

        public Task<Result> ExcluirAnimalAsync(Guid id, string usuarioExclusao)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<AnimalDto>>> ObterAnimaisAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<AnimalDto>> ObterAnimalPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
