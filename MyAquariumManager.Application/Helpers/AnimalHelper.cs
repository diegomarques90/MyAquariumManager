using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Application.Mappers
{
    public static class AnimalHelper
    {
        public static Animal ObterAnimal(CriarAnimalDto dto)
        {
            return new Animal(
                dto.CodigoConta,
                dto.UsuarioCriacao,
                dto.Nome,
                dto.NomeCientifico,
                dto.LocalAquisicao,
                dto.DataAquisicao ?? DateTime.Now,
                dto.Especie,
                dto.FaixaDoPH,
                dto.Origem,
                dto.Comportamento,
                dto.Cardumeiro,
                dto.QuantidadeMinima,
                dto.LitragemMinima,
                dto.TipoDeAlimentacao,
                dto.FaixaDeTamanho,
                dto.FaixaDeTemperatura,
                dto.TipoDeAgua,
                dto.InformacoesAdicionais
            );
        }

        public static Animal AtualizarAnimal(Animal animal, AtualizarAnimalDto dto)
        {
            animal.Atualizar(dto.UsuarioAlteracao);

            animal.Nome = dto.Nome;
            animal.NomeCientifico = dto.NomeCientifico;
            animal.LocalAquisicao = dto.LocalAquisicao;
            animal.DataAquisicao = dto.DataAquisicao ?? DateTime.Now;
            animal.Especie = dto.Especie;
            animal.FaixaDoPH = dto.FaixaDoPH;
            animal.Origem = dto.Origem;
            animal.Comportamento = dto.Comportamento;
            animal.Cardumeiro = dto.Cardumeiro;
            animal.QuantidadeMinima = dto.QuantidadeMinima;
            animal.LitragemMinima = dto.LitragemMinima;
            animal.TipoDeAlimentacao = dto.TipoDeAlimentacao;
            animal.FaixaDeTamanho = dto.FaixaDeTamanho;
            animal.FaixaDeTemperatura = dto.FaixaDeTemperatura;
            animal.TipoDeAgua = dto.TipoDeAgua;
            animal.InformacoesAdicionais = dto.InformacoesAdicionais;

            return animal;
        }


        public static AnimalDto ObterAnimalDto(Animal animal)
        {
            return new AnimalDto
            {
                Id = animal.Id,
                CodigoConta = animal.CodigoConta,
                DataCriacao = animal.DataCriacao,
                UsuarioCriacao = animal.UsuarioCriacao,
                DataAlteracao = animal.DataAlteracao,
                UsuarioAlteracao = animal.UsuarioAlteracao,
                Nome = animal.Nome,
                NomeCientifico = animal.NomeCientifico,
                LocalAquisicao = animal.LocalAquisicao,
                DataAquisicao = animal.DataAquisicao,
                Especie = animal.Especie,
                FaixaDoPH = animal.FaixaDoPH,
                Origem = animal.Origem,
                Comportamento = animal.Comportamento,
                Cardumeiro = animal.Cardumeiro,
                QuantidadeMinima = animal.QuantidadeMinima,
                LitragemMinima = animal.LitragemMinima,
                TipoDeAlimentacao = animal.TipoDeAlimentacao,
                FaixaDeTamanho = animal.FaixaDeTamanho,
                FaixaDeTemperatura = animal.FaixaDeTemperatura,
                TipoDeAgua = animal.TipoDeAgua,
                InformacoesAdicionais = animal.InformacoesAdicionais
            };
        }


        public static TableAnimalDto ObterTabelaAnimalDto(Animal animal)
        {
            return new TableAnimalDto
            {
                Id = animal.Id,
                Nome = animal.Nome,
                NomeCientifico = animal.NomeCientifico,
                LocalAquisicao = animal.LocalAquisicao,
                DataAquisicao = animal.DataAquisicao,
                Especie = animal.Especie,
                Origem = animal.Origem,
                TipoDeAgua = animal.TipoDeAgua,
            };
        }

        public static List<AnimalDto> ObterListaDeAnimalDto(List<Animal> animais)
        {
            return [.. animais.Select(animal => ObterAnimalDto(animal))];
        }

        public static List<TableAnimalDto> ObterListaDeTabelaAnimalDto(List<Animal> animais)
        {
            return [.. animais.Select(animal => ObterTabelaAnimalDto(animal))];
        }

        public static CriarAnimalDto ObterCriarAnimalDto(Animal animal)
        {
            return new CriarAnimalDto
            {
                UsuarioCriacao = animal.UsuarioCriacao,
                CodigoConta = animal.CodigoConta,
                Nome = animal.Nome,
                NomeCientifico = animal.NomeCientifico,
                LocalAquisicao = animal.LocalAquisicao,
                DataAquisicao = animal.DataAquisicao,
                Especie = animal.Especie,
                FaixaDoPH = animal.FaixaDoPH,
                Origem = animal.Origem,
                Comportamento = animal.Comportamento,
                Cardumeiro = animal.Cardumeiro,
                QuantidadeMinima = animal.QuantidadeMinima,
                LitragemMinima = animal.LitragemMinima,
                TipoDeAlimentacao = animal.TipoDeAlimentacao,
                FaixaDeTamanho = animal.FaixaDeTamanho,
                FaixaDeTemperatura = animal.FaixaDeTemperatura,
                TipoDeAgua = animal.TipoDeAgua,
                InformacoesAdicionais = animal.InformacoesAdicionais, 
            };
        }

        public static AtualizarAnimalDto ObterAtualizarAnimalDto(Animal animal)
        {
            return new AtualizarAnimalDto
            {
                UsuarioAlteracao = animal.UsuarioAlteracao,
                DataAlteracao = animal.DataAlteracao.Value,
                Nome = animal.Nome,
                NomeCientifico = animal.NomeCientifico,
                LocalAquisicao = animal.LocalAquisicao,
                DataAquisicao = animal.DataAquisicao,
                Especie = animal.Especie,
                FaixaDoPH = animal.FaixaDoPH,
                Origem = animal.Origem,
                Comportamento = animal.Comportamento,
                Cardumeiro = animal.Cardumeiro,
                QuantidadeMinima = animal.QuantidadeMinima,
                LitragemMinima = animal.LitragemMinima,
                TipoDeAlimentacao = animal.TipoDeAlimentacao,
                FaixaDeTamanho = animal.FaixaDeTamanho,
                FaixaDeTemperatura = animal.FaixaDeTemperatura,
                TipoDeAgua = animal.TipoDeAgua,
                InformacoesAdicionais = animal.InformacoesAdicionais, 
            };
        }
    }
}
