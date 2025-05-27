using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Produto(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.MARCA_QUANTIDADE_MAXIMA)]
        public string? Marca { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.MODELO_QUANTIDADE_MAXIMA)]
        public string? Modelo { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        public DateTime? DataGarantia { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_PRODUTO_OBRIGATORIO)]
        public TipoProduto TipoProduto { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_VOLTAGEM_OBRIGATORIO)]
        public TipoVoltagem TipoVoltagem { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ARMAZENAMENTO_OBRIGATORIO)]
        public TipoDeArmazenamento TipoDeArmazenamento { get; private set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();
            return (errors.Count == 0, errors);
        }
    }
}
