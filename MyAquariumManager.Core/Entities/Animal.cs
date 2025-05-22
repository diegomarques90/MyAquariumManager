using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Animal(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA)]
        public string? NomeCientifico { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.ESPECIE_QUANTIDADE_MAXIMA)]
        public string? Especie { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA)]
        public string? FaixaDoPH { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.ORIGEM_QUANTIDADE_MAXIMA)]
        public string? Origem { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.COMPORTAMENTO_QUANTIDADE_MAXIMA)]
        public string? Comportamento { get; private set; }

        [Required(ErrorMessage = BaseConstants.ANIMAL_CARDUMEIRO_OBRIGATORIO)]
        public bool Cardumeiro { get; private set; }

        [Required(ErrorMessage = BaseConstants.QUANTIDADE_MINIMA_IDEAL_OBRIGATORIA)]
        public int QuantidadeMinima { get; private set; }

        [Required(ErrorMessage = BaseConstants.LITRAGEM_MINIMA_IDEAL_OBRIGATORIA)]
        public int LitragemMinima { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ALIMENTACAO_OBRIGATORIO)]
        public TipoDeAlimentacao TipoDeAlimentacao { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTamanho { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTemperatura { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_AGUA_OBRIGATORIO)]
        public TipoDeAgua TipoDeAgua { get; private set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
