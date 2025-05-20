using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Pedra(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome da pedra é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome da pedra deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = "O nome científico da pedra deve conter no máximo 200 caracteres.")]
        public string NomeCientifico { get; private set; }

        [Required(ErrorMessage = "O tipo de efeito no PH é obrigatório.")]
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
