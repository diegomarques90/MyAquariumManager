using Microsoft.AspNetCore.Identity;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = BaseConstants.DOCUMENTO_OBRIGATORIO)]
        [MaxLength(14, ErrorMessage = BaseConstants.DOCUMENTO_QUANTIDADE_MAXIMA)]
        public string Documento { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_USUARIO_OBRIGATORIO)]
        public TipoUsuario TipoUsuario { get; private set; }
    }
}
