using KempDec.StarterDotNet.Extensions.Resources;

namespace KempDec.StarterDotNet.Extensions;

/// <summary>
/// Classe com métodos extensivos para <see cref="int"/>.
/// </summary>
public static class IntExtension
{
    /// <summary>
    /// Obtém uma saudação com base na hora especificada.
    /// </summary>
    /// <remarks>Exemplo de uma saudação: Bom dia.</remarks>
    /// <param name="hour">A hora ao qual a saudação será baseada. O valor deve estar entre 0 e 23.</param>
    /// <returns>Uma saudação com base na hora especificada.</returns>
    public static string Greeting(this int hour)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value: hour, other: 24, paramName: nameof(hour));

        return hour switch
        {
            >= 00 and < 12 => IntExtensionResource.GoodMorning,
            >= 12 and < 18 => IntExtensionResource.GoodAfternoon,
            >= 18 and < 24 => IntExtensionResource.GoodNight,
            _ => string.Empty
        };
    }
}
