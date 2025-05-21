using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Substrato(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome do substrato é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome do substrato deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [MaxLength(100, ErrorMessage = "A marca do substrato deve conter no máximo 100 caracteres.")]
        public string? Marca { get; private set; }

        [MaxLength(100, ErrorMessage = "A composição do substrato deve conter no máximo 100 caracteres.")]
        public string? Composicao { get; private set; }

        [MaxLength(100, ErrorMessage = "A cor do substrato deve conter no máximo 100 caracteres.")]
        public string? Cor { get; private set; }

        [Required(ErrorMessage = "O tipo de efeito do PH é obrigatório.")]
        public TipoDeEfeitoNoPH TipoDeEfeitoNoPH { get; private set; }

        [Required(ErrorMessage = "O tipo de água é obrigatório.")]
        public TipoDeAgua TipoDeAgua { get; private set; }

        [MaxLength(800, ErrorMessage = "As informações adicionais devem conter no máximo 800 caracteres.")]
        public string? InformacoesAdicionais { get; private set; }

        protected override (bool IsValid, List<string> Errors) ValidateSpecificRules()
        {
            return (true, new List<string>());
        }
    }
}
