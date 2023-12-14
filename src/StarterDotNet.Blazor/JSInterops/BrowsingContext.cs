using KempDec.StarterDotNet.Blazor.JSInterops.BrowsingContexts;

namespace KempDec.StarterDotNet.Blazor.JSInterops;

/// <summary>
/// Fornece instâncias de <see cref="IBrowsingContext"/> pré-construídas, que podem ser utilizadas para definir o
/// contexto de navegação.
/// </summary>
public static class BrowsingContext
{
    /// <summary>
    /// Obtém o contexto de navegação "_self".
    /// </summary>
    public static SelfBrowsingContext Self { get; } = new();

    /// <summary>
    /// Obtém o contexto de navegação "_blank".
    /// </summary>
    public static BlankBrowsingContext Blank { get; } = new();

    /// <summary>
    /// Obtém o contexto de navegação "_parent".
    /// </summary>
    public static ParentBrownsingContext Parent { get; } = new();

    /// <summary>
    /// Obtém o contexto de navegação "_top".
    /// </summary>
    public static TopBrowsingContext Top { get; } = new();
}
