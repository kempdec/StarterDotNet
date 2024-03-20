using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KempDec.StarterDotNet.Identity;

/// <summary>
/// Classe com métodos extensivos para <see cref="AuthenticationState"/>.
/// </summary>
public static class AuthenticationStateExtension
{
    /// <summary>
    /// Determina se o usuário de <see cref="ClaimsPrincipal"/> em <paramref name="authenticationState"/> tem alguma
    /// das funções especificadas, separadas por vírgula (,).
    /// </summary>
    /// <param name="authenticationState">A <see cref="Task"/> que representa a operação assíncrona, contendo as
    /// informações sobre o usuário atual autenticado, se houver algum.</param>
    /// <param name="roleNames">Os nomes das funções separadas por vírgula (,).</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo um sinalizador indicando se o
    /// usuário de <see cref="ClaimsPrincipal"/> tem alguma das funções especificadas, separadas por vírgula
    /// (,).</returns>
    public static async Task<bool> UserIsInRoleNamesAsync(this Task<AuthenticationState> authenticationState,
        string roleNames)
    {
        AuthenticationState authState = await authenticationState;

        return authState.User.IsInRoleNames(roleNames);
    }

    /// <summary>
    /// Determina se o usuário de <see cref="ClaimsPrincipal"/> em <paramref name="authenticationState"/> tem alguma
    /// das funções especificadas, separadas por vírgula (,).
    /// </summary>
    /// <param name="authenticationState">A <see cref="Task"/> que representa a operação assíncrona, contendo as
    /// informações sobre o usuário atual autenticado, se houver algum.</param>
    /// <param name="roleNames">Os nomes das funções separadas por vírgula (,).</param>
    /// <param name="func">A função que será executada, se o usuário de <see cref="ClaimsPrincipal"/> em
    /// <paramref name="authenticationState"/> tiver alguma das funções especificadas, separadas por vírgula
    /// (,).</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo um sinalizador indicando se o
    /// usuário de <see cref="ClaimsPrincipal"/> em <paramref name="authenticationState"/> tem alguma das funções
    /// especificadas, separadas por vírgula (,).</returns>
    public static async Task<bool> UserIsInRoleNamesAsync(this Task<AuthenticationState> authenticationState,
        string roleNames, Func<Task> func)
    {
        if (await UserIsInRoleNamesAsync(authenticationState, roleNames))
        {
            await func.Invoke();

            return true;
        }

        return false;
    }
}
