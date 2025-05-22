using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Pedra(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA)]
        public string NomeCientifico { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_EFEITO_PH_OBRIGATORIO)]
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
