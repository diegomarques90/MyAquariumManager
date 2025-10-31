using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Entities;

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
    }
}
