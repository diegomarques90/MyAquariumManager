using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Entities
{
    public class HistoricoDeManutencao(string usuarioCriacao) : BaseEntity(usuarioCriacao)
    {
        public string Descricao { get; private set; }
        public DateTime DataManutencao { get; private set; }
        public TipoDeManutencao TipoDeManutencao { get; private set; }
        public Guid TanqueId { get; private set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
