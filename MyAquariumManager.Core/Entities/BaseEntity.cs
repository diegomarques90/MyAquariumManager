using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public string CodigoConta { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string UsuarioCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public string UsuarioAlteracao { get; private set; }
        public DateTime? DataExclusao { get; private set; }
        public string UsuarioExclusao { get; private set; }
        public bool Ativo { get; private set; }

        public BaseEntity(string usuarioCriacao)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
            Ativo = true;
        }

        public void SetarCodigoConta(string codigoConta)
        {
            if (string.IsNullOrEmpty(codigoConta))
                throw new InvalidOperationException("Falha ao setar o código da conta. Não pode ser nulo ou vazio.");

            CodigoConta = codigoConta;
        }

        public void Inativar(string usuarioExclusao)
        {
            DataExclusao = DateTime.UtcNow;
            UsuarioExclusao = usuarioExclusao;
            Ativo = false;
        }

        public void Atualizar(string usuarioAlteracao)
        {
            DataAlteracao = DateTime.UtcNow;
            UsuarioAlteracao = usuarioAlteracao;
        }

        public abstract void Validar();
    }
}
