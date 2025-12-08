namespace MyAquariumManager.Core.Enums
{
    public enum TipoDeCrescimento
    {
        /// <summary>
        /// Plantas que levam semanas ou até meses para produzir uma folha nova. São muito resistentes e de baixa manutenção.
        /// </summary>
        Lento = 1,
        /// <summary>
        /// O ritmo mais comum. Crescem em uma velocidade controlada, exigindo atenção regular, mas não excessiva.
        /// </summary>
        Moderado = 2,
        /// <summary>
        /// Plantas que crescem rapidamente, podendo dobrar de tamanho em poucos dias ou uma semana. Consomem grandes quantidades de nutrientes da coluna d'água.
        /// </summary>
        Rapido = 3,
    }
}
