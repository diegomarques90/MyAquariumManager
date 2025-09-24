using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Application.DTOs.Animal
{
    public class TableAnimalDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCientifico { get; set; }
        public string? Especie { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public string? LocalAquisicao { get; set; }
        public TipoDeAgua TipoDeAgua { get; set; }
        public string Origem { get; set; }        
    }
}
