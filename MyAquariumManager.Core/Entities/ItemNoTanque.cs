using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class ItemNoTanque(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required]
        public Guid UnidadeDeMedidaId { get; private set; }

        [Required]
        public Guid TanqueId { get; private set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public double Quantidade { get; private set; }

        [Required(ErrorMessage = "O tipo do item é obrigatório.")]
        public TipoDoItem TipoDoItem { get; private set; }

        [Required]
        public Guid ItemId { get; private set; }

        public virtual UnidadeDeMedida UnidadeDeMedida { get; set; }


        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
