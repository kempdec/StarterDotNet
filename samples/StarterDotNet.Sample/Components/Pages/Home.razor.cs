using KempDec.StarterDotNet.Blazor.JSInterops;
using Microsoft.AspNetCore.Components;

namespace StarterDotNet.Sample.Components.Pages;

public partial class Home
{
    /// <summary>
    /// Obtém ou inicializa o responsável pela interopabilidade JavaScript do StarterDotNet.
    /// </summary>
    [Inject]
    private StarterJSInterop JS { get; init; } = null!;
}
