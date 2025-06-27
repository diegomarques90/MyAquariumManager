using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public Usuario()
        {
            
        }

        public Usuario(string documento)
        {
            Documento = documento;
            TipoUsuario = TipoUsuario.Administrador;
        }

        [Required(ErrorMessage = BaseConstants.DOCUMENTO_OBRIGATORIO)]
        [MaxLength(14, ErrorMessage = BaseConstants.DOCUMENTO_QUANTIDADE_MAXIMA)]
        public string Documento { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_USUARIO_OBRIGATORIO)]
        public TipoUsuario TipoUsuario { get; private set; }
    }
}
