namespace MyAquariumManager.Core.Entities
{
    public class UnidadeDeMedida(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Nome { get; private set; }
        public string Abreviacao { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
