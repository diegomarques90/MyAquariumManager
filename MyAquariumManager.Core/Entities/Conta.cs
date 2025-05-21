using MyAquariumManager.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Conta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome da conta é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome da conta deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A conta deve possuir um usuário vinculado. UsuarioId não informado.")]
        public string UsuarioId { get; private set; } 

        public string CriarCodigoConta()
        {
            if (string.IsNullOrEmpty(UsuarioCriacao))
                throw new InvalidOperationException("Não foi possível criar o código da conta. UsuarioCriacao não pode ser nulo ou vazio.");

            if (Id == Guid.Empty)
                throw new InvalidOperationException("Não foi possível criar o código da conta. O Id da conta informado não é válido.");

           return $"{Id}@{BaseConstants.SUFIXO_MY_AQUARIUM_MANAGER}";
        }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            return (true, new List<string>());
        }

        public virtual Usuario Usuario { get; set; }
    }
}
