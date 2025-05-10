using Microsoft.AspNetCore.Identity;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome do usuário deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O documento é obrigatório.")]
        [MaxLength(14, ErrorMessage = "O documento deve conter no máximo 14 caracteres.")]
        public string Documento { get; private set; }

        [Required(ErrorMessage = "O tipo do usuário é obrigatório.")]
        public TipoUsuario TipoUsuario { get; private set; }
    }
}
