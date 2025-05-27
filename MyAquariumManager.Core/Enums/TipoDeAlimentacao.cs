namespace MyAquariumManager.Core.Enums
{
    public enum TipoDeAlimentacao
    {
        /// <summary>
        /// Peixes que se alimentam de matéria vegetal e animal 
        /// </summary>
        Onivoro = 1,

        /// <summary>
        /// Peixes que se alimentam principalmente de carne/outros animais 
        /// </summary> 
        Carnivoro = 2,

        /// <summary>
        /// Peixes que se alimentam principalmente de matéria vegetal
        /// </summary>
        Herbivoro = 3,

        /// <summary>
        /// Peixes que se alimentam de detritos e matéria orgânica em decomposição
        /// </summary>
        Detritivoro = 4
    }
}
