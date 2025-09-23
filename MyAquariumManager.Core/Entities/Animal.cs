using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Animal : BaseEntity
    {
        public Animal(string usuarioCriacao) : base(usuarioCriacao) { }

        public Animal(string codigoConta, string usuarioCriacao, string nome, string nomeCientifico, string localAquisicao, DateTime dataAquisicao, string especie, string faixaPH, string origem, string comportamento, bool cardumeiro, int quantidadeMinima, int litragemMinima, TipoDeAlimentacao tipoDeAlimentacao, string faixaDeTamanho, string faixaDeTemperatura, TipoDeAgua tipoDeAgua, string informacoesAdicionais) : base(usuarioCriacao)
        {
            CodigoConta = codigoConta;
            Nome = nome;
            NomeCientifico = nomeCientifico;
            LocalAquisicao = localAquisicao;
            DataAquisicao = dataAquisicao;
            Especie = especie;
            FaixaDoPH = faixaPH;
            Origem = origem;
            Comportamento = comportamento;
            Cardumeiro = cardumeiro;
            QuantidadeMinima = quantidadeMinima;
            LitragemMinima = litragemMinima;
            TipoDeAlimentacao = tipoDeAlimentacao;
            FaixaDeTamanho = faixaDeTamanho;
            FaixaDeTemperatura = faixaDeTemperatura;
            TipoDeAgua = tipoDeAgua;
            InformacoesAdicionais = informacoesAdicionais;
        }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_QUANTIDADE_MAXIMA)]
        [Required(ErrorMessage = BaseConstants.NOME_OBRIGATORIO)]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA)]
        public string? NomeCientifico { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA)]
        public string? LocalAquisicao { get; set; }

        public DateTime? DataAquisicao { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.ESPECIE_QUANTIDADE_MAXIMA)]
        public string? Especie { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA)]
        public string? FaixaDoPH { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.ORIGEM_QUANTIDADE_MAXIMA)]
        public string? Origem { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.COMPORTAMENTO_QUANTIDADE_MAXIMA)]
        public string? Comportamento { get; set; }

        [Required(ErrorMessage = BaseConstants.ANIMAL_CARDUMEIRO_OBRIGATORIO)]
        public bool Cardumeiro { get; set; }

        [Required(ErrorMessage = BaseConstants.QUANTIDADE_MINIMA_IDEAL_OBRIGATORIA)]
        [Range(1, int.MaxValue, ErrorMessage = BaseConstants.QUANTIDADE_MINIMA_IDEAL_MAIOR_QUE_ZERO)]
        public int QuantidadeMinima { get; set; }

        [Required(ErrorMessage = BaseConstants.LITRAGEM_MINIMA_IDEAL_OBRIGATORIA)]
        [Range(1, int.MaxValue, ErrorMessage = BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO)]
        public int LitragemMinima { get; set; }

        [Required(ErrorMessage = BaseConstants.TIPO_ALIMENTACAO_OBRIGATORIO)]
        public TipoDeAlimentacao TipoDeAlimentacao { get;  set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTamanho { get; set; }

        [MaxLength(100, ErrorMessage = BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA)]
        public string? FaixaDeTemperatura { get; set; }

        [Required(ErrorMessage = BaseConstants.TIPO_AGUA_OBRIGATORIO)]
        public TipoDeAgua TipoDeAgua { get; set; }

        [MaxLength(800, ErrorMessage = BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA)]
        public string? InformacoesAdicionais { get; set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            var errors = new List<string>();

            if (!Enum.IsDefined(typeof(TipoDeAlimentacao), TipoDeAlimentacao))
                errors.Add(BaseConstants.TIPO_ALIMENTACAO_INVALIDO);

            if (!Enum.IsDefined(typeof(TipoDeAgua), TipoDeAgua))
                errors.Add(BaseConstants.TIPO_AGUA_INVALIDO);

            if (DataAquisicao.HasValue)
            {
                if (DataAquisicao.Value > DateTime.UtcNow)
                    errors.Add(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA);
            }

            return (errors.Count == 0, errors);
        }
    }
}
