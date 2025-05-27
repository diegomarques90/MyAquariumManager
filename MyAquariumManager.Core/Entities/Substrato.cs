using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Substrato(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.MARCA_QUANTIDADE_MAXIMA)]
        public string? Marca { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.COMPOSICAO_QUANTIDADE_MAXIMA)]
        public string? Composicao { get; private set; }

        [MaxLength(100, ErrorMessage = BaseConstants.COR_QUANTIDADE_MAXIMA)]
        public string? Cor { get; private set; }

        [Required(ErrorMessage = BaseConstants.TIPO_EFEITO_PH_OBRIGATORIO)]
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }

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
