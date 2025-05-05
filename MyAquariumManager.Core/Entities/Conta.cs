using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Core.Entities
{
    public class Conta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public Guid UsuarioId { get; private set; } 

        public string CriarCodigoConta()
        {
            if (string.IsNullOrEmpty(UsuarioCriacao))
                throw new InvalidOperationException("Não foi possível criar o código da conta. UsuarioCriacao não pode ser nulo ou vazio.");

            if (Id == Guid.Empty)
                throw new InvalidOperationException("Não foi possível criar o código da conta. O Id da conta informado não é válido.");

           return $"{Id}@{BaseConstants.SUFIXO_MY_AQUARIUM_MANAGER}";
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
