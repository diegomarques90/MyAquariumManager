using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using MyAquariumManager.Core.Helpers;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public Usuario(string documento, string email, string userName)
        {
            Documento = documento;
            Email = email;
            UserName = userName;
            TipoUsuario = TipoUsuario.Administrador;
        }

        [Required(ErrorMessage = BaseConstants.DOCUMENTO_OBRIGATORIO)]
        [MaxLength(14, ErrorMessage = BaseConstants.DOCUMENTO_QUANTIDADE_MAXIMA)]
        public string Documento { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_USUARIO_OBRIGATORIO)]
        public TipoUsuario TipoUsuario { get; private set; }

        [Required(ErrorMessage = BaseConstants.EMAIL_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.EMAIL_QUANTIDADE_MAXIMA)]
        public override string? Email { get => base.Email; set => base.Email = value; }

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

        private (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();

            if (!ValidadorDeDocumentosHelper.EhUmDocumentoValido(Documento))
                errors.Add(BaseConstants.DOCUMENTO_INVALIDO);

            return (errors.Count == 0, errors);
        }
    }
}
