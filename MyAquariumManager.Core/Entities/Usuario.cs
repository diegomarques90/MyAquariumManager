using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
