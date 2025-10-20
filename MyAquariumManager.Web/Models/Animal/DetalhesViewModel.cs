using MyAquariumManager.Core.Enums;
using MyAquariumManager.Application.DTOs.Animal;

namespace MyAquariumManager.Web.Models.Animal
{
    public class DetalhesViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
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

        public static DetalhesViewModel FromAnimalDto(AnimalDto dto)
        {
            return new DetalhesViewModel
            {
                Id = dto.Id,
                DataCriacao = dto.DataCriacao,
                UsuarioCriacao = dto.UsuarioCriacao,
                DataAlteracao = dto.DataAlteracao,
                UsuarioAlteracao = dto.UsuarioAlteracao,
                DataExclusao = dto.DataExclusao,
                UsuarioExclusao = dto.UsuarioExclusao,
                Nome = dto.Nome,
                NomeCientifico = dto.NomeCientifico,
                LocalAquisicao = dto.LocalAquisicao,
                DataAquisicao = dto.DataAquisicao,
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
