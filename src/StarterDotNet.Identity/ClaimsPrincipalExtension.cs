using System.Security.Claims;

namespace KempDec.StarterDotNet.Identity;

/// <summary>
/// Classe com métodos extensivos para <see cref="ClaimsPrincipal"/>.
/// </summary>
public static class ClaimsPrincipalExtension
{
    /// <summary>
    /// Determina se o usuário de <see cref="ClaimsPrincipal"/> tem alguma das funções especificadas, separadas por
    /// vírgula (,).
    /// </summary>
    /// <param name="principal"><see cref="ClaimsPrincipal"/> do usuário.</param>
    /// <param name="roleNames">Os nomes das funções separadas por vírgula (,).</param>
    /// <returns>Um sinalizador indicando se o usuário de <see cref="ClaimsPrincipal"/> tem alguma das funções
    /// especificadas, separadas por vírgula (,).</returns>
    public static bool IsInRoleName(this ClaimsPrincipal principal, string roleNames) =>
        roleNames.Split(',').Any(principal.IsInRole);
}
