using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Produto(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome do produto deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [MaxLength(100, ErrorMessage = "A marca do produto deve conter no máximo 100 caracteres.")]
        public string? Marca { get; private set; }

        [MaxLength(100, ErrorMessage = "O modelo do produto deve conter no máximo 100 caracteres.")]
        public string? Modelo { get; private set; }

        [MaxLength(100, ErrorMessage = "O local da aquisição deve conter no máximo 100 caracteres.")]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        public DateTime? DataGarantia { get; private set; }

        [Required(ErrorMessage = "O tipo do produto é obrigatório.")]
        public TipoProduto TipoProduto { get; private set; }

        [Required(ErrorMessage = "O tipo da voltagem é obrigatório.")]
        public TipoVoltagem TipoVoltagem { get; private set; }

        [Required(ErrorMessage = "O tipo de armazenamento é obrigatório.")]
        public TipoDeArmazenamento TipoDeArmazenamento { get; private set; }

        [MaxLength(800, ErrorMessage = "As informações adicionais devem conter no máximo 800 caracteres.")]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            return (true, new List<string>());
        }
    }
}
