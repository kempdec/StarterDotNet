using Microsoft.AspNetCore.WebUtilities;

namespace KempDec.StarterDotNet.AppRoutes;

/// <summary>
/// Fornece abstração para uma rota do aplicativo.
/// </summary>
public abstract class AppRouteBase : IAppRoute
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="AppRouteBase"/>.
    /// </summary>
    /// <param name="route">A rota do aplicativo.</param>
    /// <param name="parameters">Os parâmetros da rota. Esses parâmetros serão separados por /. Para parâmetro de
    /// consulta use <see cref="Params"/>.</param>
    public AppRouteBase(string route, params string[] parameters)
    {
        foreach (string parameter in parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameter))
            {
                route += $"/{parameter}";
            }
        }

        Route = route;
    }

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
    public string Route { get; }

    /// <summary>
    /// Obtém ou define os parâmetros da rota do aplicativo.
    /// </summary>
    protected virtual Dictionary<string, string?> Params { get; } = [];

    /// <inheritdoc/>
    public override string ToString() => FullRoute;
}
