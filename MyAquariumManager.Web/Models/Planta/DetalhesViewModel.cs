using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Web.Models.Planta
{
    public class DetalhesViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioCriacao { get; set; }
        public string DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string Nome { get; set; }
        public string? NomeCientifico { get; set; }
        public string? LocalAquisicao { get; set; }
        public string? DataAquisicao { get; set; }
        public string? FaixaDeTamanho { get; set; }
        public TipoDeCrescimento TipoDeCrescimento { get; set; }
        public TipoDeIluminacao TipoDeIluminacao { get; set; }
        public string? FaixaDoPH { get; set; }
        public string? FaixaDeTemperatura { get; set; }
        public string? NivelDeCutivo { get; set; }
        public TipoDePlantio TipoDePlantio { get; set; }
        public string? FormaDeReproducao { get; set; }
        public string ExigeCO2 { get; set; }
        public string? InformacoesAdicionais { get; set; }

        public static DetalhesViewModel FromPlantaDto(PlantaDto dto) 
        {
            return new DetalhesViewModel
            {
                Id = dto.Id,
                DataCriacao = dto.DataCriacao,
                UsuarioCriacao = dto.UsuarioCriacao,
                DataAlteracao = dto.DataAlteracao.HasValue ? dto.DataAlteracao.Value.ToString("dd/MM/yyyy") : string.Empty,
                UsuarioAlteracao = dto.UsuarioAlteracao,
                DataExclusao = dto.DataExclusao.HasValue ? dto.DataExclusao.Value.ToString("dd/MM/yyyy") : string.Empty,
                UsuarioExclusao = dto.UsuarioExclusao,
                Nome = dto.Nome,
                NomeCientifico = dto.NomeCientifico,
                LocalAquisicao = dto.LocalAquisicao,
                DataAquisicao = dto.DataAquisicao.HasValue ? dto.DataAquisicao.Value.ToString("dd/MM/yyyy") : string.Empty,
                FaixaDeTamanho = dto.FaixaDeTamanho,
                TipoDeCrescimento = dto.TipoDeCrescimento,
                TipoDeIluminacao = dto.TipoDeIluminacao,
                FaixaDoPH = dto.FaixaDoPH,
                FaixaDeTemperatura = dto.FaixaDeTemperatura,
                NivelDeCutivo = dto.NivelDeCutivo,
                TipoDePlantio = dto.TipoDePlantio,
                FormaDeReproducao = dto.FormaDeReproducao,
                ExigeCO2 = dto.ExigeCO2 ? "Sim" : "Não",
                InformacoesAdicionais = dto.InformacoesAdicionais
            };
        }
    }
}
