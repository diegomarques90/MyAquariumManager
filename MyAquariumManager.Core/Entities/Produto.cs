using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Produto(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string? Marca { get; private set; }
        public string? Modelo { get; private set; }
        public string? LocalAquisicao { get; private set; }
        public DateTime? DataAquisicao { get; private set; }
        public DateTime? DataGarantia { get; private set; }
        public TipoProduto TipoProduto { get; private set; }
        public TipoVoltagem TipoVoltagem { get; private set; }
        public TipoDeArmazenamento TipoDeArmazenamento { get; private set; }
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
