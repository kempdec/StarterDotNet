using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace KempDec.StarterDotNet.Identity;

/// <summary>
/// Classe com métodos extensivos para <see cref="IdentityError"/>.
/// </summary>
public static class IdentityErrorExtension
{
    /// <summary>
    /// Obtém o nome da propriedade de <see cref="IdentityError"/>.
    /// </summary>
    /// <param name="error">O <see cref="IdentityError"/>.</param>
    /// <returns>O nome da propriedade de <see cref="IdentityError"/>.</returns>
    /// <exception cref="InvalidOperationException">É lançado quando <see cref="IdentityErrorPropertyNames"/> não
    /// existe uma propriedade para <see cref="IdentityError.Code"/>.</exception>
    public static string GetPropertyName(this IdentityError error) =>
        error.GetPropertyName(new IdentityErrorPropertyNames());

    /// <summary>
    /// Obtém o nome da propriedade de <see cref="IdentityError"/>.
    /// </summary>
    /// <param name="error">O <see cref="IdentityError"/>.</param>
    /// <param name="propertyNames">O nome das propriedades de <see cref="IdentityError"/>.</param>
    /// <returns>O nome da propriedade de <see cref="IdentityError"/>.</returns>
    /// <exception cref="InvalidOperationException">É lançado quando <see cref="IdentityErrorPropertyNames"/> não
    /// existe uma propriedade para <see cref="IdentityError.Code"/>.</exception>
    public static string GetPropertyName(this IdentityError error, IdentityErrorPropertyNames propertyNames)
    {
        PropertyInfo property = propertyNames.GetType().GetProperty(error.Code)
            ?? throw new InvalidOperationException($"Não existe uma propriedade com o código '{error.Code}'.");

        return property.GetValue(error)!.ToString()!;
    }
}
