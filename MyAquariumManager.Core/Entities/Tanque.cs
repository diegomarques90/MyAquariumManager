using MyAquariumManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAquariumManager.Core.Entities
{
    public class Tanque(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        [Required(ErrorMessage = "O nome do tanque é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome do tanque deve conter no máximo 200 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A largura do tanque é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public double Largura { get; private set; }

        [Required(ErrorMessage = "O comprimento do tanque é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O comprimento deve ser maior que zero.")]
        public double Comprimento { get; private set; }

        [Required(ErrorMessage = "A altura do tanque é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        public double Altura { get; private set; }

        [Required(ErrorMessage = "A litragem do tanque é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "A litragem deve ser maior que zero.")]
        public double Litragem { get; private set; }

        [MaxLength(100, ErrorMessage = "O local de aquisição deve conter no máximo 100 caracteres.")]
        public string? LocalAquisicao { get; private set; }

        public DateTime? DataAquisicao { get; private set; }

        public DateTime? DataMontagem { get; private set; }

        [Required(ErrorMessage = "Deve informar se o tanque está em operação.")]
        public bool EmOperacao { get; private set; }

        [Required(ErrorMessage = "O tipo de água do tanque é obrigatório.")]
        public TipoDeAgua TipoDeAgua { get; private set; }

        [Required(ErrorMessage = "O tipo do tanque é obrigatório.")]
        public TipoDoTanque TipoDoTanque { get; private set; }

        [MaxLength(800, ErrorMessage = "As informações adicionais devem conter no máximo 800 caracteres.")]
        public string? InformacoesAdicionais { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }

        public void CalcularLitragem()
        {
            if (Comprimento <= 0 || Largura <= 0 || Altura <= 0)
                throw new InvalidOperationException("As dimensões do tanque devem ser maiores que zero.");

            Litragem = Math.Round(Comprimento * Largura * Altura / 1000, 1, MidpointRounding.AwayFromZero);
        }
    }
}
