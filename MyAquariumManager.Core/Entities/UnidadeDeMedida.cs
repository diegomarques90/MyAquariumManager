using MyAquariumManager.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class UnidadeDeMedida(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = BaseConstants.ABREVIACAO_OBRIGATORIA)]
        [MaxLength(2, ErrorMessage = BaseConstants.ABREVIACAO_QUANTIDADE_MAXIMA)]
        public string Abreviacao { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
