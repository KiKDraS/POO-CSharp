namespace Biblioteca.Interfaces
{
    public interface ITipo
    {
        /// <summary>
        ///     Método para calcular la fuerza del golpe en base al cálculo golpe + debilidad
        /// </summary>
        /// <param name="golpe"></param>
        /// <returns>Interger que representa la fuerza del golpe</returns>
        int Debilidad(int golpe);

        /// <summary>
        ///     Método para calcular la fuerza del golpe en base al cálculo golpe - resistencia
        /// </summary>
        /// <param name="golpe"></param>
        /// <returns></returns>
        int Resistencia(int golpe);
    }
}
