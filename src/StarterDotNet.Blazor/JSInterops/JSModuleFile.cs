namespace KempDec.StarterDotNet.Blazor.JSInterops;

/// <summary>
/// Representa um arquivo de um módulo JavaScript.
/// </summary>
/// <remarks>Inicializa uma nova instância de <see cref="JSModuleFile"/>.</remarks>
/// <param name="moduleName">O nome do módulo JavaScript.</param>
/// <param name="moduleFilePath">O caminho do arquivo do módulo JavaScript.</param>
public class JSModuleFile(string moduleName, string moduleFilePath)
{
    /// <summary>
    /// Obtém o nome do módulo JavaScript.
    /// </summary>
    public string ModuleName { get; } = moduleName;

    /// <summary>
    /// Obtém o caminho do arquivo do módulo JavaScript.
    /// </summary>
    public string ModuleFilePath { get; } = moduleFilePath;
}
