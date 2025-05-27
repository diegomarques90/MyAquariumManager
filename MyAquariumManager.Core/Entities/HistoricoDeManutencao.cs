using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class HistoricoDeManutencao(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.DESCRICAO_OBRIGATORIA)]
        [MaxLength(800, ErrorMessage = BaseConstants.DESCRICAO_QUANTIDADE_MAXIMA)]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = BaseConstants.DATA_MANUTENCAO_OBRIGATORIA)]
        public DateTime DataManutencao { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_MANUTENCAO_OBRIGATORIO)]
        public TipoDeManutencao TipoDeManutencao { get; private set; }

        [Required]
        public Guid TanqueId { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
