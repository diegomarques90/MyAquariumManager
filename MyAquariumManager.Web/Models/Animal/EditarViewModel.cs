using MyAquariumManager.Core.Enums;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Web.Models.Animal
{
    public class EditarViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCientifico { get; set; }
        public string? LocalAquisicao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public string? Especie { get; set; }
        public string? FaixaDoPH { get; set; }
        public string? Origem { get; set; }
        public string? Comportamento { get; set; }
        public bool Cardumeiro { get; set; }
        public int QuantidadeMinima { get; set; }
        public int LitragemMinima { get; set; }
        public TipoDeAlimentacao TipoDeAlimentacao { get; set; }
        public string? FaixaDeTamanho { get; set; }
        public string? FaixaDeTemperatura { get; set; }
        public TipoDeAgua TipoDeAgua { get; set; }
        public string? InformacoesAdicionais { get; set; }

        public static EditarViewModel FromAnimalDto(AnimalDto dto)
        {
            return new EditarViewModel
            {
                Id = dto.Id,
                Nome = dto.Nome,
                NomeCientifico = dto.NomeCientifico,
                LocalAquisicao = dto.LocalAquisicao,
                DataAquisicao = dto.DataAquisicao.HasValue ? dto.DataAquisicao.Value : null,
                Especie = dto.Especie,
                FaixaDoPH = dto.FaixaDoPH,
                Origem = dto.Origem,
                Comportamento = dto.Comportamento,
                Cardumeiro = dto.Cardumeiro,
                QuantidadeMinima = dto.QuantidadeMinima,
                LitragemMinima = dto.LitragemMinima,
                TipoDeAlimentacao = dto.TipoDeAlimentacao,
                FaixaDeTamanho = dto.FaixaDeTamanho,
                FaixaDeTemperatura = dto.FaixaDeTemperatura,
                TipoDeAgua = dto.TipoDeAgua,
                InformacoesAdicionais = dto.InformacoesAdicionais
            };
        }
    }
}
