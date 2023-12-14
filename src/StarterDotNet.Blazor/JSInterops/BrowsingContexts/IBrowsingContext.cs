namespace KempDec.StarterDotNet.Blazor.JSInterops.BrowsingContexts;

/// <summary>
/// Fornece abstração para um contexto de navegação.
/// </summary>
public interface IBrowsingContext
{
    /// <summary>
    /// Obtém o nome do contexto de navegação.
    /// </summary>
    public string Name { get; }
}
