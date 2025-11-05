using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Entities;
using System.Net.NetworkInformation;

namespace MyAquariumManager.Application.Helpers
{
    public static class PlantaHelper
    {
        public static PlantaDto ObterPlantaDto(Planta planta)
        {
            return new PlantaDto
            {
                Id = planta.Id,
                CodigoConta = planta.CodigoConta,
                DataCriacao = planta.DataCriacao,
                UsuarioCriacao = planta.UsuarioCriacao,
                DataAlteracao = planta.DataAlteracao,
                UsuarioAlteracao = planta.UsuarioAlteracao,
                Nome = planta.Nome,
                NomeCientifico = planta.NomeCientifico ?? string.Empty,
                LocalAquisicao = planta.LocalAquisicao,
                DataAquisicao = planta.DataAquisicao,
                FaixaDeTamanho = planta.FaixaDeTamanho,
                TipoDeCrescimento = planta.TipoDeCrescimento,
                TipoDeIluminacao = planta.TipoDeIluminacao,
                FaixaDoPH = planta.FaixaDoPH,
                FaixaDeTemperatura = planta.FaixaDeTemperatura,
                NivelDeCutivo = planta.NivelDeCutivo,
                TipoDePlantio = planta.TipoDePlantio,
                FormaDeReproducao = planta.FormaDeReproducao,
                ExigeCO2 = planta.ExigeCO2,
                InformacoesAdicionais = planta.InformacoesAdicionais
            };
        }

        public static Planta ObterPlanta(CriarPlantaDto dto)
        {
            return new Planta(dto.CodigoConta, dto.UsuarioCriacao, dto.Nome, dto.NomeCientifico, dto.LocalAquisicao, dto.DataAquisicao, dto.FaixaDeTamanho, dto.TipoDeCrescimento, dto.TipoDeIluminacao, dto.FaixaDoPH, dto.FaixaDeTemperatura, dto.NivelDeCutivo, dto.TipoDePlantio, dto.FormaDeReproducao, dto.ExigeCO2, dto.InformacoesAdicionais);
        }

        public static List<TablePlantaDto> ObterListaDeTabelaPlantaDto(List<Planta> plantas)
        {
            return [.. plantas.Select(planta => ObterTabelaPlantaDto(planta))];
        }

        public static TablePlantaDto ObterTabelaPlantaDto(Planta planta)
        {
            return new TablePlantaDto
            {
                Id = planta.Id,
                Nome = planta.Nome,
                NomeCientifico = planta.NomeCientifico,
                LocalAquisicao = planta.LocalAquisicao,
                DataAquisicao = planta.DataAquisicao,
                TipoDeCrescimento = planta.TipoDeCrescimento,
                TipoDeIluminacao = planta.TipoDeIluminacao,
                TipoDePlantio = planta.TipoDePlantio,
                ExigeCO2 = planta.ExigeCO2
            };
        }

        public static CriarPlantaDto ObterCriarPlantaDto(Planta planta)
        {
            return new CriarPlantaDto
            {
                CodigoConta = planta.CodigoConta,
                UsuarioCriacao = planta.UsuarioCriacao,
                Nome = planta.Nome,
                NomeCientifico = planta.NomeCientifico,
                LocalAquisicao = planta.LocalAquisicao,
                DataAquisicao = planta.DataAquisicao,
                FaixaDeTamanho = planta.FaixaDeTamanho,
                TipoDeCrescimento = planta.TipoDeCrescimento,
                TipoDeIluminacao = planta.TipoDeIluminacao,
                FaixaDoPH = planta.FaixaDoPH,
                FaixaDeTemperatura = planta.FaixaDeTemperatura,
                NivelDeCutivo = planta.NivelDeCutivo,
                TipoDePlantio = planta.TipoDePlantio,
                FormaDeReproducao = planta.FormaDeReproducao,
                ExigeCO2 = planta.ExigeCO2,
                InformacoesAdicionais = planta.InformacoesAdicionais
            };
        }

        public static AtualizarPlantaDto ObterAtualizarPlantaDto(Planta planta)
        {
            return new AtualizarPlantaDto
            {
                Id = planta.Id,
                UsuarioAlteracao = planta.UsuarioAlteracao!,
                Nome = planta.Nome,
                NomeCientifico = planta.NomeCientifico,
                LocalAquisicao = planta.LocalAquisicao,
                DataAquisicao = planta.DataAquisicao,
                FaixaDeTamanho = planta.FaixaDeTamanho,
                TipoDeCrescimento = planta.TipoDeCrescimento,
                TipoDeIluminacao = planta.TipoDeIluminacao,
                FaixaDoPH = planta.FaixaDoPH,
                FaixaDeTemperatura = planta.FaixaDeTemperatura,
                NivelDeCutivo = planta.NivelDeCutivo,
                TipoDePlantio = planta.TipoDePlantio,
                FormaDeReproducao = planta.FormaDeReproducao,
                ExigeCO2 = planta.ExigeCO2,
                InformacoesAdicionais = planta.InformacoesAdicionais
            };
        }

        public static List<PlantaDto> ObterListaDePlantaDto(List<Planta> plantas)
        {
            return [.. plantas.Select(planta => ObterPlantaDto(planta))];
        }
    }
}
