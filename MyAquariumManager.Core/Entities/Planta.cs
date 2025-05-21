using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Planta(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome da planta é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome da planta deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O nome científico da planta é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome científico da planta deve conter no máximo 200 caracteres.")]
        public string? NomeCientifico { get; private set; }

        [MaxLength(100, ErrorMessage = "O local da aquisição deve conter no máximo 100 caracteres.")]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa de tamanho deve conter no máximo 100 caracteres.")]
        public string? FaixaDeTamanho { get; private set; }

        [Required(ErrorMessage = "O tipo de crescimento é obrigatório.")]
        public TipoDeCrescimento TipoDeCrescimento { get; private set; }

        [Required(ErrorMessage = "O tipo de iluminação é obrigatório")]
        public TipoDeIluminacao TipoDeIluminacao { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa do PH deve conter no máximo 100 caracteres.")]
        public string? FaixaDoPH { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa de temperatura deve conter no máximo 100 caracteres.")]
        public string? FaixaDeTemperatura { get; private set; }

        [MaxLength(100, ErrorMessage = "O nível de cultivo deve conter no máximo 100 caracteres.")]
        public string? NivelDeCutivo { get; private set; }

        [Required(ErrorMessage = "O tipo de plantio é obrigatório.")]
        public TipoDePlantio TipoDePlantio { get; private set; }

        [MaxLength(100, ErrorMessage = "A forma de reprodução deve conter no máximo 100 caracteres")]
        public string? FormaDeReproducao { get; private set; }

        [Required(ErrorMessage = "É obrigatório informar se a planta exige CO2.")]
        public bool ExigeCO2 { get; private set; }

        [MaxLength(800, ErrorMessage = "As informações adicionais devem conter no máximo 800 caracteres.")]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            return (true, new List<string>());
        }
    }
}
