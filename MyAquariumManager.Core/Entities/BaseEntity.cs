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

        public BaseEntity(string codigoConta, string usuarioCriacao)
        {
            Id = Guid.NewGuid();
            CodigoConta = codigoConta;
            DataCriacao = DateTime.UtcNow;
            UsuarioCriacao = usuarioCriacao;
            Ativo = true;
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
