using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Planta : BaseEntity
    {
        public Planta(string usuarioCriacao) : base(usuarioCriacao) { }

        public Planta(string codigoConta, string usuarioCriacao, string nome, string? nomeCientifico, string? localAquisicao, DateTime? dataAquisicao, string? faixaDeTamanho, TipoDeCrescimento tipoDeCrescimento, TipoDeIluminacao tipoDeIluminacao, string? faixaDoPH, string? faixaDeTemperatura, string? nivelDeCutivo, TipoDePlantio tipoDePlantio, string? formaDeReproducao, bool exigeCO2, string? informacoesAdicionais) : base(usuarioCriacao)
        {
            CodigoConta = codigoConta;
            Nome = nome;
            NomeCientifico = nomeCientifico;
            LocalAquisicao = localAquisicao;
            DataAquisicao = dataAquisicao;
            FaixaDeTamanho = faixaDeTamanho;
            TipoDeCrescimento = tipoDeCrescimento;
            TipoDeIluminacao = tipoDeIluminacao;
            FaixaDoPH = faixaDoPH;
            FaixaDeTemperatura = faixaDeTemperatura;
            NivelDeCutivo = nivelDeCutivo;
            TipoDePlantio = tipoDePlantio;
            FormaDeReproducao = formaDeReproducao;
            ExigeCO2 = exigeCO2;
            InformacoesAdicionais = informacoesAdicionais;
        }

        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA)]
        public string? NomeCientifico { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; set; }

        public DateTime? DataAquisicao { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTamanho { get; set; }

        [Required(ErrorMessage = BaseConstants.TIPO_CRESCIMENTO_OBRIGATORIO)]
        public TipoDeCrescimento TipoDeCrescimento { get; set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ILUMINACAO_OBRIGATORIO)]
        public TipoDeIluminacao TipoDeIluminacao { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA)]
        public string? FaixaDoPH { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTemperatura { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.NIVEL_CULTIVO_QUANTIDADE_MAXIMA)]
        public string? NivelDeCutivo { get; set; }

        [Required(ErrorMessage = BaseConstants.TIPO_PLANTIO_OBRIGATORIO)]
        public TipoDePlantio TipoDePlantio { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FORMA_REPRODUCAO_QUANTIDADE_MAXIMA)]
        public string? FormaDeReproducao { get; set; }

        [Required]
        public bool ExigeCO2 { get; set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();

            if (!Enum.IsDefined(typeof(TipoDeCrescimento), TipoDeCrescimento))
                errors.Add(BaseConstants.TIPO_CRESCIMENTO_INVALIDO);

            if (!Enum.IsDefined(typeof(TipoDeIluminacao), TipoDeIluminacao))
                errors.Add(BaseConstants.TIPO_ILUMINACAO_INVALIDO);

            if (!Enum.IsDefined(typeof(TipoDePlantio), TipoDePlantio))
                errors.Add(BaseConstants.TIPO_PLANTIO_INVALIDO);

            if (DataAquisicao.HasValue)
            {
                if (DataAquisicao.Value > DateTime.UtcNow)
                    errors.Add(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA);
            }

            return (errors.Count == 0, errors);
        }
    }
}
