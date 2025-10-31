using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Application.DTOs.Planta
{
    public class CriarPlantaDto
    {
        public string? CodigoConta { get; set; }
        public string? UsuarioCriacao { get; set; }
        public string Nome { get; set; }
        public string NomeCientifico { get; set; }
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

    }
}
