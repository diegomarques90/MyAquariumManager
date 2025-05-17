using MyAquariumManager.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required(ErrorMessage = "O Id não pode ser nulo ou vazio.")]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O código da conta não pode ser nulo ou vazio.")]
        [MaxLength(200, ErrorMessage = "O código da conta deve conter no máximo 200 caracteres.")]
        public string CodigoConta { get; private set; }

        [Required(ErrorMessage = "A data de criação não pode ser nula.")]
        public DateTime DataCriacao { get; private set; }

        [Required(ErrorMessage = "O usuário de criação não pode ser nulo ou vazio.")]
        [MaxLength(200, ErrorMessage = "O usuário de criação deve conter no máximo 200 caracteres.")]
        public string UsuarioCriacao { get; private set; }

        public DateTime? DataAlteracao { get; private set; }

        [MaxLength(200, ErrorMessage = "O usuário de alteração deve conter no máximo 200 caracteres.")]
        public string UsuarioAlteracao { get; private set; }

        public DateTime? DataExclusao { get; private set; }

        [MaxLength(200, ErrorMessage = "O usuário de exclusão deve conter no máximo 200 caracteres.")]
        public string UsuarioExclusao { get; private set; }

        [Required(ErrorMessage = "É obrigatório informar se o registro está ativo.")]
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
