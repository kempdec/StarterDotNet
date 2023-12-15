using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace KempDec.StarterDotNet.Blazor;

/// <summary>
/// Fornece instâncias <see cref="IComponentRenderMode"/> pré-construídas que podem ser usadas durante a renderização.
/// </summary>
public static class StarterRenderMode
{
    /// <summary>
    /// Obtém um <see cref="IComponentRenderMode"/> que representa a renderização interativamente no servidor por meio
    /// da hospedagem do Blazor Server sem pré-renderização do lado do servidor.
    /// </summary>
    public static InteractiveServerRenderMode InteractiveServerWithoutPrerendering { get; } = new(prerender: false);
}
