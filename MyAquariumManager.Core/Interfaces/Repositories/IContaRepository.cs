using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Core.Interfaces.Repositories
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        Task<bool> ExisteContaComOCodigo(string codigoConta);
        Task<Conta> ObterContaPorUsuarioId(string usuarioId);
        Task<Conta> ObterContaPorNome(string nome);
    }
}
