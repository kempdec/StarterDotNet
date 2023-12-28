using KempDec.StarterDotNet.Extensions.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace KempDec.StarterDotNet.Extensions;

/// <summary>
/// Classe com métodos extensivos para <see cref="object"/>.
/// </summary>
public static class ObjectExtension
{
    /// <summary>
    /// Lança <see cref="InvalidOperationException"/> quando <paramref name="obj"/> é nulo.
    /// </summary>
    /// <remarks>Esse método é para ser usado somente com propriedades ou campos.</remarks>
    /// <param name="obj">O objeto ao qual a exceção será lançada.</param>
    /// <param name="propertyOrFieldName">O nome da propriedade ou campo ao qual a exceção será lançada.</param>
    /// <exception cref="InvalidOperationException">É lançado quando <paramref name="obj"/> é nulo.</exception>
    public static void ThrowIfNull([NotNull] this object? obj,
        [CallerArgumentExpression(nameof(obj))] string? propertyOrFieldName = null)
    {
        if (obj is null)
        {
            throw new InvalidOperationException(
                ObjectExtensionResource.PropertyOrFieldUninitialized.FormatWith(propertyOrFieldName));
        }
    }
}
