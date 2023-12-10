using System.Reflection;

namespace KempDec.StarterDotNet.Reflection;

/// <summary>
/// Classe com métodos auxiliares para <see cref="Assembly"/>.
/// </summary>
public static class AssemblyHelper
{
    /// <summary>
    /// Obtém todas as classes do assembly em execução, se houver alguma, que implemente o tipo da interface
    /// especificado.
    /// </summary>
    /// <remarks>É necessário que as classes tenham um construtor público vazio.</remarks>
    /// <typeparam name="T">O tipo da interface das classes.</typeparam>
    /// <returns>Todas as classes do assembly em execução, se houver alguma, que implemente o tipo da interface
    /// especificado.</returns>
    public static IEnumerable<T?> GetAllClassesWithInterface<T>() =>
        Assembly.GetExecutingAssembly().GetAllClassesWithInterface<T>();

    /// <summary>
    /// Obtém todas as classes do assembly em execução, se houver alguma, que implemente o tipo da interface
    /// especificado.
    /// </summary>
    /// <remarks>É necessário que as classes tenham um construtor público vazio.</remarks>
    /// <typeparam name="T">O tipo das classes.</typeparam>
    /// <param name="interfaceType">O tipo da interface das classes.</param>
    /// <returns>Todas as classes do assembly em execução, se houver alguma, que implemente o tipo da interface
    /// especificado.</returns>
    public static IEnumerable<T?> GetAllClassesWithInterface<T>(Type interfaceType) =>
        Assembly.GetExecutingAssembly().GetAllClassesWithInterface<T>(interfaceType);

    /// <summary>
    /// Obtém os tipos de todas as classes do assembly em execução, se houver alguma, que implemente o tipo da
    /// interface especificado.
    /// </summary>
    /// <param name="interfaceType">O tipo da interface das classes.</param>
    /// <returns>Os tipos de todas as classes do assembly em execução, se houver alguma, que implemente o tipo da
    /// interface especificado.</returns>
    public static IEnumerable<Type> GetAllClassesWithInterface(Type interfaceType) =>
        Assembly.GetExecutingAssembly().GetAllClassesWithInterface(interfaceType);
}
