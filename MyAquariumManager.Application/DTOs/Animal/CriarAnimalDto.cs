﻿using MyAquariumManager.Application.DTOs.Commons;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Application.DTOs.Animal
{
    public class CriarAnimalDto : BaseDto
    {
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
    }
}
