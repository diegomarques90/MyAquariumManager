using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Mappers;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using MyAquariumManager.Core.Interfaces.Repositories;

namespace MyAquariumManager.Application.Services
{
    public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository = animalRepository;

        public async Task<Result<AnimalDto>> AtualizarAnimalAsync(AtualizarAnimalDto model)
        {
            var animal = await _animalRepository.GetByIdAsync(model.Id);

            if (animal is null) 
                return Result<AnimalDto>.Failure([BaseConstants.ANIMAL_NAO_EXISTE_OU_JA_FOI_EXCLUIDO]);

            AnimalHelper.AtualizarAnimal(animal, model);

            var (isValid, errors) = animal.Validate();

            if (!isValid)
                return Result<AnimalDto>.Failure(errors);

            try
            {
                await _animalRepository.UpdateAsync(animal);
                await _animalRepository.SaveChangesAsync();

                var animalDto = AnimalHelper.ObterAnimalDto(animal);
                return Result<AnimalDto>.Success(animalDto, HttpCode.OK);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados na atualização do animal: {dbEx.Message}");
                return Result<AnimalDto>.Failure(["Erro de persistência atualizar o animal. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar animais: {ex.Message}");
                return Result<AnimalDto>.Failure([$"Ocorreu um erro inesperado ao atualizar o animal: {ex.Message}"]);
            }
        }

        public async Task<Result<AnimalDto>> CadastrarAnimalAsync(CriarAnimalDto model)
        {
            var animal = AnimalHelper.ObterAnimal(model);

            var (isValid, errors) = animal.Validate();

            if (!isValid)
                return Result<AnimalDto>.Failure(errors);

            try
            {
                await _animalRepository.AddAsync(animal);
                await _animalRepository.SaveChangesAsync();

                var animalDto = AnimalHelper.ObterAnimalDto(animal);
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

        public async Task<Result<List<TableAnimalDto>>> CarregarTabelaAnimaisAsync()
        {
            try
            {
                var animais = await _animalRepository.GetAllAsync();
                var tabelaAnimais = AnimalHelper.ObterListaDeTabelaAnimalDto(animais);

                return Result<List<TableAnimalDto>>.Success(tabelaAnimais);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao carregar a tabela animais: {dbEx.Message}");
                return Result<List<TableAnimalDto>>.Failure(["Erro de persistência ao carregar a tabela animais. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar a tabela animais: {ex.Message}");
                return Result<List<TableAnimalDto>>.Failure([$"Ocorreu um erro inesperado ao carregar a tabela animais: {ex.Message}"]);
            }
        }

        public async Task<Result> ExcluirAnimalAsync(Guid id, string usuarioExclusao)
        {
            try
            {
                var animal = await _animalRepository.GetByIdAsync(id);
                
                if (animal == null)
                    return Result.Failure([BaseConstants.ANIMAL_NAO_EXISTE_OU_JA_FOI_EXCLUIDO]);

                animal.Inativar(usuarioExclusao);
                await _animalRepository.UpdateAsync(animal);
                await _animalRepository.SaveChangesAsync();

                return Result.Success();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados na exclusão de animais: {dbEx.Message}");
                return Result.Failure(["Erro de persistência ao excluir o animal. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir animais: {ex.Message}");
                return Result.Failure([$"Ocorreu um erro inesperado ao excluir o animal: {ex.Message}"]);
            }
        }

        public async Task<Result<List<AnimalDto>>> ObterAnimaisAsync()
        {
            try
            {
                var animais = await _animalRepository.GetAllAsync();
                var animalDtos = AnimalHelper.ObterListaDeAnimalDto(animais);

                return Result<List<AnimalDto>>.Success(animalDtos);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao obter a lista de todos os animais: {dbEx.Message}");
                return Result<List<AnimalDto>>.Failure(["Erro de persistência ao obter a lista de todos os animais. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a lista de todos os animais: {ex.Message}");
                return Result<List<AnimalDto>>.Failure([$"Ocorreu um erro inesperado ao obter a lista de todos os animais: {ex.Message}"]);
            }
        }

        public async Task<Result<AnimalDto>> ObterAnimalPorIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return Result<AnimalDto>.Failure([BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO]);

                var animal = await _animalRepository.GetByIdAsync(id);
                
                if (animal == null)
                    return Result<AnimalDto>.Failure([BaseConstants.ANIMAL_NAO_EXISTE_OU_JA_FOI_EXCLUIDO]);

                var animalDto = AnimalHelper.ObterAnimalDto(animal);
                return Result<AnimalDto>.Success(animalDto);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao obter o animal: {dbEx.Message}");
                return Result<AnimalDto>.Failure(["Erro de persistência ao obter o animal. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter o animal: {ex.Message}");
                return Result<AnimalDto>.Failure([$"Ocorreu um erro inesperado ao obter o animal: {ex.Message}"]);
            }
        }
    }
}
