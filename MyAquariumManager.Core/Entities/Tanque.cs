using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Tanque(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = BaseConstants.LARGURA_OBRIGATORIA)]
        [Range(0.01, double.MaxValue, ErrorMessage = BaseConstants.LARGURA_QUANTIDADE_MINIMA)]
        public double Largura { get; private set; }

        [Required(ErrorMessage = BaseConstants.COMPRIMENTO_OBRIGATORIO)]
        [Range(0.01, double.MaxValue, ErrorMessage = BaseConstants.COMPRIMENTO_QUANTIDADE_MINIMA)]
        public double Comprimento { get; private set; }

        [Required(ErrorMessage = BaseConstants.ALTURA_OBRIGATORIA)]
        [Range(0.01, double.MaxValue, ErrorMessage = BaseConstants.ALTURA_QUANTIDADE_MINIMA)]
        public double Altura { get; private set; }

        [Required(ErrorMessage = BaseConstants.LITRAGEM_OBRIGATORIA)]
        [Range(0.01, double.MaxValue, ErrorMessage = BaseConstants.LITRAGEM_MINIMA)]
        public double Litragem { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        public DateTime? DataMontagem { get; private set; }

        [Required]
        public bool EmOperacao { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_AGUA_OBRIGATORIO)]
        public TipoDeAgua TipoDeAgua { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_TANQUE_OBRIGATORIO)]
        public TipoDoTanque TipoDoTanque { get; private set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            
            if (Comprimento <= 0 || Largura <= 0 || Altura <= 0)
                errors.Add(BaseConstants.DIMENSOES_TANQUE_INVALIDAS);

            return (errors.Count == 0, errors);
        }

        public void CalcularLitragem() => Litragem = Math.Round(Comprimento * Largura * Altura / 1000, 1, MidpointRounding.AwayFromZero);
    }
}
