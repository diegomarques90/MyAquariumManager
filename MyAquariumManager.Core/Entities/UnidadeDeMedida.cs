using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class UnidadeDeMedida(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome da unidade de medida é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome da unidade de medida deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A abreviação da unidade de medida é obrigatória.")]
        [MaxLength(2, ErrorMessage = "A abreviação da unidade de medida deve conter no máximo 2 caracteres.")]
        public string Abreviacao { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
