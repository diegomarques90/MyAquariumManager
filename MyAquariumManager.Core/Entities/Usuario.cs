using Microsoft.AspNetCore.Identity;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
    }
}
