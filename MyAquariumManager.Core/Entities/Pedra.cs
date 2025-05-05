using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Pedra(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string NomeCientifico { get; private set; }
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
