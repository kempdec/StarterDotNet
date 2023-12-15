using KempDec.StarterDotNet.Blazor.JSInterops.BrowsingContexts;
using Microsoft.JSInterop;

namespace KempDec.StarterDotNet.Blazor.JSInterops;

/// <summary>
/// Responsável pela interopabilidade JavaScript do StarterDotNet.
/// </summary>
/// <remarks>Use essa classe com injeção de dependência no seu aplicativo.</remarks>
public class StarterJSInterop : JSInteropBase
{
    /// <summary>
    /// A <see cref="Task"/> que representa a operação assíncrona, contendo a referência do objeto JavaScript do módulo.
    /// </summary>
    private readonly Task<IJSObjectReference> _moduleTask;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="StarterJSInterop"/>.
    /// </summary>
    /// <param name="js">O runtime JavaScript ao qual as chamadas devem ser despachadas.</param>
    public StarterJSInterop(IJSRuntime js) : base(js) =>
        _moduleTask = ImportModuleFileAsync(moduleName: "StarterDotNet",
            moduleFilePath: "./_content/KempDec.StarterDotNet.Blazor/js/interop.js");

    /// <summary>
    /// Copia o texto especificado para a área de transferência.
    /// </summary>
    /// <param name="text">O texto a ser copiado para a área de transferência.</param>
    /// <returns>O <see cref="ValueTask"/> que representa a operação assíncrona, contendo um sinalizador indicando se o
    /// texto especificado foi copiado para a área de transferência..</returns>
    public async ValueTask<bool> CopyToClipboardAsync(string text)
    {
        IJSObjectReference module = await _moduleTask;

        return await module.InvokeAsync<bool>("copyToClipboard", text);
    }

    /// <summary>
    /// Foca em um elemento HTML, se houver algum, que possui o identificador especificado.
    /// </summary>
    /// <param name="elementId">O identificador do elemento HTML a ser buscado.</param>
    /// <returns>O <see cref="ValueTask"/> que representa a operação assíncrona.</returns>
    public async ValueTask FocusOnElementIdAsync(string elementId)
    {
        IJSObjectReference module = await _moduleTask;

        await module.InvokeVoidAsync("focusOnElementId", elementId);
    }

    /// <summary>
    /// Abre uma nova janela ou guia do navegador com a URL especificada.
    /// </summary>
    /// <param name="url">A URL da nova janela ou guia do navegador.</param>
    /// <returns>O <see cref="ValueTask"/> que representa a operação assíncrona.</returns>
    public ValueTask OpenAsync(string url) => OpenAsync(url, BrowsingContext.Blank);

    /// <summary>
    /// Abre uma nova janela ou guia do navegador com a URL especificada.
    /// </summary>
    /// <param name="url">A URL da nova janela ou guia do navegador.</param>
    /// <param name="target">O contexto de navegação. Instâncias pré-construídas estão disponíveis em
    /// <see cref="BrowsingContext"/>.</param>
    /// <returns>O <see cref="ValueTask"/> que representa a operação assíncrona.</returns>
    public ValueTask OpenAsync(string url, IBrowsingContext target) =>
        Runtime.InvokeVoidAsync("open", url, target.Name);
}
