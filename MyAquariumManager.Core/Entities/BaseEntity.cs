using MyAquariumManager.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required(ErrorMessage = BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO)]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = BaseConstants.CODIGO_CONTA_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.CODIGO_CONTA_QUANTIDADE_MAXIMA)]
        public string CodigoConta { get; set; }

        [Required(ErrorMessage = BaseConstants.DATA_CRIACAO_OBRIGATORIA)]
        public DateTime DataCriacao { get; private set; }

        [Required(ErrorMessage = BaseConstants.USUARIO_CRIACAO_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.USUARIO_CRIACAO_QUANTIDADE_MAXIMA)]
        public string UsuarioCriacao { get; private set; }

        public DateTime? DataAlteracao { get; private set; }

        [MaxLength(200, ErrorMessage = BaseConstants.USUARIO_ALTERACAO_QUANTIDADE_MAXIMA)]
        public string UsuarioAlteracao { get; private set; } = string.Empty;

        public DateTime? DataExclusao { get; private set; }

        [MaxLength(200, ErrorMessage = BaseConstants.USUARIO_EXCLUSAO_QUANTIDADE_MAXIMA)]
        public string UsuarioExclusao { get; private set; } = string.Empty;

        [Required]
        public bool Ativo { get; private set; }

        public BaseEntity(string usuarioCriacao)
        {
            Id = Guid.NewGuid();
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

        public (bool IsValid, List<string> Errors) Validate()
        {
            var errors = new List<string>();

            ValidatePropertiesDataAnnotations(errors);

            var (derivedIsValid, derivedErrors) = ValidateSpecificRules();
            
            if (!derivedIsValid)
                errors.AddRange(derivedErrors);

            return (errors.Count == 0, errors);
        }

        private void ValidatePropertiesDataAnnotations(List<string> errors)
        {
            var validationContext = new ValidationContext(this, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(instance: this, validationContext: validationContext, validationResults: validationResults, validateAllProperties: true))
            {
                foreach (var result in validationResults)
                {
                    if (result is null || result.ErrorMessage is null)
                        continue;
                    errors.Add(result.ErrorMessage);
                }
            }
        }

        protected abstract (bool IsValid, List<string> Errors) ValidateSpecificRules();
    }
}
