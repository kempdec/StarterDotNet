using Microsoft.AspNetCore.WebUtilities;

namespace KempDec.StarterDotNet.AppRoutes;

/// <summary>
/// Fornece abstração para uma rota do aplicativo.
/// </summary>
/// <remarks>Inicializa uma nova instância de <see cref="AppRouteBase"/>.</remarks>
/// <param name="route">A rota do aplicativo.</param>
public abstract class AppRouteBase(string route) : IAppRoute
{
    /// <summary>
    /// Retorna a representação da rota do aplicativo em uma cadeia de caracteres.
    /// </summary>
    /// <param name="route">A rota do aplicativo.</param>
    public static implicit operator string(AppRouteBase route) => route.ToString();

    /// <summary>
    /// Obtém a rota completa do aplicativo.
    /// </summary>
    public string FullRoute => QueryHelpers.AddQueryString(Route, Params);

    /// <inheritdoc/>
    public string Route { get; } = route;

    /// <summary>
    /// Obtém ou define os parâmetros da rota do aplicativo.
    /// </summary>
    protected virtual Dictionary<string, string?> Params { get; } = [];

    /// <inheritdoc/>
    public override string ToString() => FullRoute;
}
