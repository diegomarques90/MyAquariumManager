using MyAquariumManager.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Conta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = BaseConstants.CONTA_USUARIO_NAO_VINCULADO)]
        public string UsuarioId { get; private set; } 

        public string CriarCodigoConta()
        {
            var (isValid, errors) = ValidateSpecificRules();

            if (!isValid)
                throw new InvalidOperationException(string.Join(", \n", errors));

            return $"{Id}@{BaseConstants.SUFIXO_MY_AQUARIUM_MANAGER}";
        }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(UsuarioCriacao))
                errors.Add(BaseConstants.FALHA_CRIACAO_CODIGO_CONTA_USUARIO_CRIACAO_NULO);

            if (Id == Guid.Empty)
                errors.Add(BaseConstants.FALHA_CRIACAO_CODIGO_CONTA_ID_INVALIDO);

            return (errors.Count == 0, errors);
        }

        public virtual Usuario Usuario { get; set; }
    }
}
