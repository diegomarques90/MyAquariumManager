using MyAquariumManager.Core.Constants;
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

        [Required(ErrorMessage = BaseConstants.QUANTIDADE_OBRIGATORIA)]
        [Range(0.01, double.MaxValue, ErrorMessage = BaseConstants.QUANTIDADE_MINIMA_OBRIGATORIA)]
        public double Quantidade { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ITEM_OBRIGATORIO)]
        public TipoDoItem TipoDoItem { get; private set; }

        [Required]
        public Guid ItemId { get; private set; }

        public virtual UnidadeDeMedida UnidadeDeMedida { get; set; }


        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
