using System.Reflection;

namespace KempDec.StarterDotNet.Reflection;

/// <summary>
/// Classe com métodos extensivos para <see cref="Assembly"/>.
/// </summary>
public static class AssemblyExtension
{
    /// <summary>
    /// Obtém todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface
    /// especificado.
    /// </summary>
    /// <remarks>É necessário que as classes tenham um construtor público vazio.</remarks>
    /// <typeparam name="T">O tipo da interface das classes.</typeparam>
    /// <param name="assembly">O assembly que contém as classes.</param>
    /// <returns>Todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface
    /// especificado.</returns>
    public static IEnumerable<T?> GetAllClassesWithInterface<T>(this Assembly assembly) =>
        GetAllClassesWithInterface<T>(assembly, typeof(T));

    /// <summary>
    /// Obtém todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface
    /// especificado.
    /// </summary>
    /// <remarks>É necessário que as classes tenham um construtor público vazio.</remarks>
    /// <typeparam name="T">O tipo das classes.</typeparam>
    /// <param name="assembly">O assembly que contém as classes.</param>
    /// <param name="interfaceType">O tipo da interface das classes.</param>
    /// <returns>Todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface
    /// especificado.</returns>
    public static IEnumerable<T?> GetAllClassesWithInterface<T>(this Assembly assembly, Type interfaceType) =>
        GetAllClassesWithInterface(assembly, interfaceType)
            .Select(e => (T?)Activator.CreateInstance(e));

    /// <summary>
    /// Obtém os tipos de todas as classes do assembly especificado, se houver alguma, que implemente o tipo da
    /// interface especificado.
    /// </summary>
    /// <param name="assembly">O assembly que contém as classes.</param>
    /// <param name="interfaceType">O tipo da interface das classes.</param>
    /// <returns>Os tipos de todas das classes do assembly especificado, se houver alguma, que implemente o tipo da
    /// interface especificado.</returns>
    public static IEnumerable<Type> GetAllClassesWithInterface(this Assembly assembly, Type interfaceType)
    {
        Type[] types = assembly.GetTypes();

        return types.Where(e => e.IsClass && !e.IsAbstract && e.GetInterfaces().Contains(interfaceType));
    }
}
