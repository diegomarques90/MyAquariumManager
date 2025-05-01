using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Core.Entities
{
    public class Conta(string codigoConta, string usuarioCriacao, string nome, Guid usuarioId) : BaseEntity(codigoConta, usuarioCriacao)
    {
        public string Nome { get; private set; } = nome;
        public Guid UsuarioId { get; private set; } = usuarioId;

        public string CriarCodigoConta(Guid usuarioId) => $"{usuarioId}@{BaseConstants.SUFIXO_MAM}";

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
