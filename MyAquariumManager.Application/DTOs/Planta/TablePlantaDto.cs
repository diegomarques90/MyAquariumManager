using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Application.DTOs.Planta
{
    public class TablePlantaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? NomeCientifico { get; set; }
        public string? LocalAquisicao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public TipoDeCrescimento TipoDeCrescimento { get; set; }
        public TipoDeIluminacao TipoDeIluminacao { get; set; }
        public TipoDePlantio TipoDePlantio { get; set; }
        public bool ExigeCO2 { get; set; }
    }
}
