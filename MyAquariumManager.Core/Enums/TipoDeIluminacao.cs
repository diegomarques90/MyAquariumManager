namespace MyAquariumManager.Core.Enums
{
    public enum TipoDeIluminacao
    {
        /// <summary>
        /// Abaixo de 0.25 W/L de 10 a 20 lm/L
        /// Plantas de baixa manutenção e crescimento lento, que toleram pouca luz. Geralmente não necessitam de injeção de CO2.
        /// </summary>
        Baixa = 1,
        /// <summary>
        /// Entre 0.25 W/L e 0.5 W/L de 20 a 40 lm/L
        /// Plantas de midground e algumas carpetes de crescimento moderado. Requer CO2 para plantas mais exigentes e maior crescimento.
        /// </summary>
        Media = 2,
        /// <summary>
        /// Acime de 0.5 W/L de 40 lm/L ou mais
        /// Plantas de crescimento rápido, carpetes exigentes e vermelhas. Exige obrigatoriamente injeção de CO2, substrato fértil e fertilização líquida completa.
        /// </summary>
        Alta = 3
    }
}
