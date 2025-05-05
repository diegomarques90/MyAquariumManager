using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Animal(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string? NomeCientifico { get; private set; }
        public string? LocalAquisicao { get; private set; }
        public DateTime? DataAquisicao { get; set; }
        public string? Especie { get; private set; }
        public string? FaixaDoPH { get; private set; }
        public string? Origem { get; private set; }
        public string? Comportamento { get; private set; }
        public bool Cardumeiro { get; private set; }
        public int QuantidadeMinima { get; private set; }
        public int LitragemMinima { get; private set; }
        public TipoDeAlimentacao TipoDeAlimentacao { get; private set; }
        public string? FaixaDeTamanho { get; private set; }
        public string? FaixaDeTemperatura { get; private set; }
        public TipoDeAgua TipoDeAgua { get; private set; }
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
