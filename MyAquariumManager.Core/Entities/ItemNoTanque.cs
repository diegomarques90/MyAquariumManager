using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class ItemNoTanque(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public Guid UnidadeMedidaId { get; private set; }
        public Guid TanqueId { get; private set; }
        public double Quantidade { get; private set; }
        public TipoDoItem TipoDoItem { get; private set; }
        public Guid ItemId { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
