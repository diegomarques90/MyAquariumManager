using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Planta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string? NomeCientifico { get; private set; }
        public string ?LocalAquisicao { get; private set; }
        public DateTime? DataAquisicao { get; private set; }
        public string? FaixaDeTamanho { get; private set; }
        public TipoDeCrescimento TipoDeCrescimento { get; private set; }
        public TipoDeIluminacao TipoDeIluminacao { get; private set; }
        public string? FaixaDoPH { get; private set; }
        public string? FaixaDeTemperatura { get; private set; }
        public string? NivelDeCutivo { get; private set; }
        public TipoDePlantio TipoDePlantio { get; private set; }
        public string? FormaDeReproducao { get; private set; }
        public bool ExigeCO2 { get; private set; }
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
