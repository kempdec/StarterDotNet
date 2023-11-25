namespace KempDec.StarterDotNet.AppRoutes;

/// <summary>
/// Fornece abstração para uma rota do aplicativo.
/// </summary>
public interface IAppRoute
{
    /// <summary>
    /// Obtém a rota do aplicativo.
    /// </summary>
    public string Route { get; }
}
