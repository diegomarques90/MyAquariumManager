using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Animal(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome do animal é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome do animal deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = "O nome científico do animal deve conter no máximo 200 caracteres.")]
        public string? NomeCientifico { get; private set; }

        [MaxLength(100, ErrorMessage = "O local da aquisição deve conter no máximo 100 caracteres.")]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; set; }

        [MaxLength(100, ErrorMessage = "A espécie do animal deve conter no máximo 100 caracteres.")]
        public string? Especie { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa do PH deve conter no máximo 100 caracteres.")]
        public string? FaixaDoPH { get; private set; }

        [MaxLength(100, ErrorMessage = "A origem do animal deve conter no máximo 100 caracteres.")]
        public string? Origem { get; private set; }

        [MaxLength(100, ErrorMessage = "O comportamento do animal deve conter no máximo 100 caracteres.")]
        public string? Comportamento { get; private set; }

        [Required(ErrorMessage = "É obrigatório informar se o animal é cardumeiro.")]
        public bool Cardumeiro { get; private set; }

        [Required(ErrorMessage = "A quantidade mínima ideal é obrigatória.")]
        public int QuantidadeMinima { get; private set; }

        [Required(ErrorMessage = "A litragem mínima ideal é obrigatória.")]
        public int LitragemMinima { get; private set; }

        [Required(ErrorMessage = "O tipo de alimentação é obrigatório.")]
        public TipoDeAlimentacao TipoDeAlimentacao { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa de tamanho deve conter no máximo 100 caracteres.")]
        public string? FaixaDeTamanho { get; private set; }

        [MaxLength(100, ErrorMessage = "A faixa de temperatura deve conter no máximo 100 caracteres.")]
        public string? FaixaDeTemperatura { get; private set; }

        [Required(ErrorMessage = "O tipo de água é obrigatório.")]
        public TipoDeAgua TipoDeAgua { get; private set; }

        [MaxLength(800, ErrorMessage = "As informações adicionais devem conter no máximo 800 caracteres.")]
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
