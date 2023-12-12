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
    /// Foca em um elemento HTML, se houver algum, que possui o identificador especificado.
    /// </summary>
    /// <param name="elementId">O identificador do elemento HTML a ser buscado.</param>
    /// <returns>O <see cref="ValueTask"/> que representa a operação assíncrona.</returns>
    public async ValueTask FocusOnElementIdAsync(string elementId)
    {
        IJSObjectReference module = await _moduleTask;

        await module.InvokeVoidAsync("focusOnElementId", elementId);
    }
}
