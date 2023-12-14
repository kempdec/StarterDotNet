namespace KempDec.StarterDotNet.Blazor.JSInterops.BrowsingContexts;

/// <summary>
/// Fornece abstração para um contexto de navegação.
/// </summary>
/// <remarks>Inicializa uma nova instância de <see cref="BrowsingContextBase"/>.</remarks>
/// <param name="name">O nome do contexto de navegação.</param>
public abstract class BrowsingContextBase(string name) : IBrowsingContext
{
    /// <inheritdoc/>
    public string Name { get; } = name;

    /// <inheritdoc/>
    public override string ToString() => Name;
}
