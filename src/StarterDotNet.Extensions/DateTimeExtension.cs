namespace KempDec.StarterDotNet.Extensions;

/// <summary>
/// Classe com métodos extensivos para <see cref="DateTime"/>.
/// </summary>
public static class DateTimeExtension
{
    /// <summary>
    /// Obtém uma saudação com base na hora do <see cref="DateTime"/> especificado.
    /// </summary>
    /// <remarks>Exemplo de uma saudação: Bom dia.</remarks>
    /// <param name="date">O <see cref="DateTime"/> ao qual a saudação será baseada.</param>
    /// <returns>Uma saudação com base na hora do <see cref="DateTime"/> especificado.</returns>
    public static string Greeting(this DateTime date) => date.Hour.Greeting();
}
