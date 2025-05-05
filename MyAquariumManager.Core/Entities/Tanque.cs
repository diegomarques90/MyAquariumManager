using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Tanque(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public double Largura { get; private set; }
        public double Comprimento { get; private set; }
        public double Altura { get; private set; }
        public double Litragem { get; private set; }
        public string? LocalAquisicao { get; private set; }
        public DateTime? DataAquisicao { get; private set; }
        public DateTime? DataMontagem { get; private set; }
        public bool EmOperacao { get; private set; }
        public TipoDeAgua TipoDeAgua { get; private set; }
        public TipoDoTanque TipoDoTanque { get; private set; }
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }

        public void CalcularLitragem()
        {
            if (Comprimento <= 0 || Largura <= 0 || Altura <= 0)
                throw new InvalidOperationException("As dimensões do tanque devem ser maiores que zero.");

            Litragem = Math.Round(Comprimento * Largura * Altura / 1000, 1, MidpointRounding.AwayFromZero);
        }
    }
}
