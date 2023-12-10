using Microsoft.JSInterop;

namespace KempDec.StarterDotNet.Blazor.JSInterops;

/// <summary>
/// Fornece abstração para interopabilidade JavaScript.
/// </summary>
/// <remarks>Inicializa uma nova instância de <see cref="JSInteropBase"/>.</remarks>
/// <param name="js">O runtime JavaScript ao qual as chamadas devem ser despachadas.</param>
public abstract class JSInteropBase(IJSRuntime js) : IAsyncDisposable
{
    /// <summary>
    /// Os módulos JavaScript.
    /// </summary>
    private readonly Dictionary<string, Lazy<Task<IJSObjectReference>>> _modules = [];

    /// <summary>
    /// Obtém o runtime JavaScript ao qual as chamadas devem ser despachadas.
    /// </summary>
    public IJSRuntime JS { get; } = js;

    /// <summary>
    /// Adiciona um módulo JavaScript.
    /// </summary>
    /// <param name="name">O nome do módulo JavaScript a ser adicionado.</param>
    /// <param name="jsObject">A referência do objeto do módulo JavaScript a ser adicionado.</param>
    private void AddModule(string name, ValueTask<IJSObjectReference> jsObject) =>
        _modules.Add(name, new Lazy<Task<IJSObjectReference>>(jsObject.AsTask));

    /// <inheritdoc/>
    public virtual async ValueTask DisposeAsync()
    {
        if (_modules.Count is 0)
        {
            return;
        }

        foreach (KeyValuePair<string, Lazy<Task<IJSObjectReference>>> module in _modules)
        {
            if (!module.Value.IsValueCreated)
            {
                continue;
            }

            IJSObjectReference moduleObject = await module.Value.Value;

            await moduleObject.DisposeAsync();

            RemoveModule(module.Key);
        }
    }

    /// <summary>
    /// Obtém o módulo JavaScript.
    /// </summary>
    /// <param name="name">O nome do módulo a ser buscado.</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo a referência do objeto do módulo
    /// JavaScript.</returns>
    public Task<IJSObjectReference> GetModuleAsync(string name) => _modules[name].Value;

    /// <summary>
    /// Obtém o módulo JavaScript, se houver algum, que possui o nome especificado.
    /// </summary>
    /// <param name="name">O nome do módulo a ser buscado.</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo a referência do objeto do módulo
    /// JavaScript.</returns>
    public Task<IJSObjectReference>? GetModuleOrDefaultAsync(string name) => _modules.GetValueOrDefault(name)?.Value;

    /// <summary>
    /// Importa o arquivo do módulo JavaScript especificado.
    /// </summary>
    /// <param name="moduleFile">O arquivo do módulo JavaScript a ser importado.</param>
    public void ImportModuleFile(JSModuleFile moduleFile)
    {
        ValueTask<IJSObjectReference> jsObject = JS.InvokeAsync<IJSObjectReference>("import",
            moduleFile.ModuleFilePath);

        AddModule(moduleFile.ModuleName, jsObject);
    }

    /// <summary>
    /// Importa o arquivo do módulo JavaScript especificado.
    /// </summary>
    /// <param name="moduleName">O nome do módulo JavaScript.</param>
    /// <param name="moduleFilePath">O caminho do arquivo do módulo JavaScript.</param>
    public void ImportModuleFile(string moduleName, string moduleFilePath)
    {
        var moduleFile = new JSModuleFile(moduleName, moduleFilePath);

        ImportModuleFile(moduleFile);
    }

    /// <summary>
    /// Importa o arquivo do módulo JavaScript especificado.
    /// </summary>
    /// <param name="moduleFile">O arquivo do módulo JavaScript a ser importado.</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo a referência do objeto do módulo
    /// JavaScript importado.</returns>
    public Task<IJSObjectReference> ImportModuleFileAsync(JSModuleFile moduleFile)
    {
        ImportModuleFile(moduleFile);

        return GetModuleAsync(moduleFile.ModuleName);
    }

    /// <summary>
    /// Importa o arquivo do módulo JavaScript especificado.
    /// </summary>
    /// <param name="moduleName">O nome do módulo JavaScript.</param>
    /// <param name="moduleFilePath">O caminho do arquivo do módulo JavaScript.</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona, contendo a referência do objeto do módulo
    /// JavaScript importado.</returns>
    public Task<IJSObjectReference> ImportModuleFileAsync(string moduleName, string moduleFilePath)
    {
        var moduleFile = new JSModuleFile(moduleName, moduleFilePath);

        return ImportModuleFileAsync(moduleFile);
    }

    /// <summary>
    /// Remove um módulo JavaScript, se houver algum, que possui o nome especificado.
    /// </summary>
    /// <param name="moduleName">O nome do módulo a ser removido.</param>
    /// <returns>Um sinalizador indicando se o módulo JavaScript foi removido.</returns>
    public bool RemoveModule(string moduleName) => _modules.Remove(moduleName);
}
