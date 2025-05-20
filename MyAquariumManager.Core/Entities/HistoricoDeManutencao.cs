using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class HistoricoDeManutencao(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(800, ErrorMessage = "A descrição deve conter no máximo 800 caracteres.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "A data da manutenção é obrigatória.")]
        public DateTime DataManutencao { get; private set; }

        [Required(ErrorMessage = "O tipo de manutenção é obrigatório.")]
        public TipoDeManutencao TipoDeManutencao { get; private set; }

        [Required(ErrorMessage = "A identificação do tanque é obrigatória.")]
        public Guid TanqueId { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
