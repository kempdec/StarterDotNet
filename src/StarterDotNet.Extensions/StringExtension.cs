using System.Diagnostics.CodeAnalysis;

namespace KempDec.StarterDotNet.Extensions;

/// <summary>
/// Classe com métodos extensivos para <see cref="string"/>.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Substitui o item de formato em uma cadeia de caracteres especificada pela representação de cadeia de caracteres
    /// de um objeto correspondente em uma matriz especificada.
    /// </summary>
    /// <param name="format">Uma cadeia de caracteres de formato composto.</param>
    /// <param name="args">Uma matriz de objetos que contém zero ou mais objetos a serem formatados.</param>
    /// <returns>Uma cópia do <paramref name="format"/> na qual os itens de formato foram substituídos pela
    /// representação de cadeia de caracteres dos objetos correspondentes no <paramref name="args"/>.</returns>
    public static string FormatWith([StringSyntax(StringSyntaxAttribute.CompositeFormat)] this string format,
        params object?[] args) => string.Format(format, args);
}
