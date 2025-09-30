namespace MyAquariumManager.Core.Common
{
    public class DataTableResult<T> where T : class
    {
        public List<T> Dados { get; set; } = [];
        public int TotalGeral { get; set; }
        public int TotalFiltrado { get; set; }
    }
}
