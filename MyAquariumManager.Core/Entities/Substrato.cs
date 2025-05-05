using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Substrato(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string? Marca { get; private set; }
        public string? Composicao { get; private set; }
        public string? Cor { get; private set; }
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }
        public TipoDeAgua TipoDeAgua { get; private set; }
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
