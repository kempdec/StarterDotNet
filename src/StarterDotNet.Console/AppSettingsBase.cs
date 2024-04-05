using Microsoft.Extensions.Configuration;

namespace KempDec.StarterDotNet.Console;

/// <summary>
/// Fornece abstração para a associação recursiva das configurações do aplicativo.
/// </summary>
/// <typeparam name="T">O tipo da associação recursiva das configurações do aplicativo.</typeparam>
public record AppSettingsBase<T> where T : new()
{
    /// <summary>
    /// A extensão do arquivo de configuração.
    /// </summary>
    private const string ConfigFileExtension = ".json";

    /// <summary>
    /// Obtém a instância da associação recursiva das configurações do aplicativo.
    /// </summary>
    /// <param name="fileName">O nome do arquivo de configuração JSON.</param>
    /// <param name="optional">Um sinalizador indicando se o arquivo de configuração é opcional.</param>
    /// <returns>A instância da associação recursiva das configurações do aplicativo.</returns>
    protected static T GetInstance(string fileName, bool optional = false)
    {
        if (fileName.Contains(ConfigFileExtension))
        {
            fileName = fileName.Replace(ConfigFileExtension, string.Empty);
        }

        string envFileName = $"{fileName}.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}";

        string configPath = Path.Combine(Environment.CurrentDirectory, fileName + ConfigFileExtension);
        string envConfigPath = Path.Combine(Environment.CurrentDirectory, envFileName + ConfigFileExtension);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile(configPath, optional)
            .AddJsonFile(envConfigPath, optional: true)
            .AddEnvironmentVariables()
            .Build();

        return configuration.Get<T>() ?? new T();
    }
}
