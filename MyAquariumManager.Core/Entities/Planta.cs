using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Planta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA)]
        public string? NomeCientifico { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTamanho { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_CRESCIMENTO_OBRIGATORIO)]
        public TipoDeCrescimento TipoDeCrescimento { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ILUMINACAO_OBRIGATORIO)]
        public TipoDeIluminacao TipoDeIluminacao { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA)]
        public string? FaixaDoPH { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTemperatura { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.NIVEL_CULTIVO_QUANTIDADE_MAXIMA)]
        public string? NivelDeCutivo { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_PLANTIO_OBRIGATORIO)]
        public TipoDePlantio TipoDePlantio { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FORMA_REPRODUCAO_QUANTIDADE_MAXIMA)]
        public string? FormaDeReproducao { get; private set; }

        [Required]
        public bool ExigeCO2 { get; private set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
