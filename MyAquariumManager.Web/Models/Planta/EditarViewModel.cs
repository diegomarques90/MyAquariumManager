using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Web.Models.Planta
{
    public class EditarViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? NomeCientifico { get; set; }
        public string? LocalAquisicao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public string? FaixaDeTamanho { get; set; }
        public TipoDeCrescimento TipoDeCrescimento { get; set; }
        public TipoDeIluminacao TipoDeIluminacao { get; set; }
        public string? FaixaDoPH { get; set; }
        public string? FaixaDeTemperatura { get; set; }
        public string? NivelDeCutivo { get; set; }
        public TipoDePlantio TipoDePlantio { get; set; }
        public string? FormaDeReproducao { get; set; }
        public bool ExigeCO2 { get; set; }
        public string? InformacoesAdicionais { get; set; }

        public static EditarViewModel FromPlantaDto(PlantaDto dto)
        {
            return new EditarViewModel
            {
                Id = dto.Id,
                Nome = dto.Nome,
                NomeCientifico = dto.NomeCientifico,
                LocalAquisicao = dto.LocalAquisicao,
                DataAquisicao = dto.DataAquisicao.HasValue ? dto.DataAquisicao.Value : null,
                FaixaDeTamanho = dto.FaixaDeTamanho,
                TipoDeCrescimento = dto.TipoDeCrescimento,
                TipoDeIluminacao = dto.TipoDeIluminacao,
                FaixaDoPH = dto.FaixaDoPH,
                FaixaDeTemperatura = dto.FaixaDeTemperatura,
                NivelDeCutivo = dto.NivelDeCutivo,
                TipoDePlantio = dto.TipoDePlantio,
                FormaDeReproducao = dto.FormaDeReproducao,
                ExigeCO2 = dto.ExigeCO2,
                InformacoesAdicionais = dto.InformacoesAdicionais
            };
        }
    }
}
