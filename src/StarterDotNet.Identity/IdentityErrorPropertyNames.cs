using Microsoft.AspNetCore.Identity;

namespace KempDec.StarterDotNet.Identity;

/// <summary>
/// Define o nome das propriedades de <see cref="IdentityError"/>.
/// </summary>
/// <remarks>Inicializa uma nova instância de <see cref="IdentityErrorPropertyNames"/>.</remarks>
/// <param name="username">O nome da propriedade para erros de nome de usuário. Define <see cref="DuplicateUserName"/>
/// e <see cref="InvalidUserName"/>.</param>
/// <param name="email">O nome da propriedade para erros de e-mail. Define <see cref="DuplicateEmail"/> e
/// <see cref="InvalidEmail"/>.</param>
/// <param name="password">O nome da propriedade para erros de senha. Define <see cref="PasswordMismatch"/>,
/// <see cref="PasswordRequiresDigit"/>, <see cref="PasswordRequiresLower"/>,
/// <see cref="PasswordRequiresNonAlphanumeric"/>, <see cref="PasswordRequiresUniqueChars"/>,
/// <see cref="PasswordRequiresUpper"/>, <see cref="PasswordTooShort"/> e <see cref="UserAlreadyHasPassword"/>.</param>
/// <param name="code">O nome da propriedade para erros de código. Define <see cref="InvalidToken"/> e
/// <see cref="RecoveryCodeRedemptionFailed"/>.</param>
/// <param name="role">O nome da propriedade para erros de função. Define <see cref="DuplicateRoleName"/>,
/// <see cref="InvalidRoleName"/>, <see cref="UserAlreadyInRole"/> e <see cref="UserNotInRole"/>.</param>
/// <param name="other">O nome da propriedade para outros erros. Define <see cref="ConcurrencyFailure"/>,
/// <see cref="DefaultError"/>, <see cref="LoginAlreadyAssociated"/> e <see cref="UserLockoutNotEnabled"/>.</param>
public class IdentityErrorPropertyNames(string username = "Username", string email = "Email",
    string password = "Password", string code = "Code", string role = "Name", string other = "Email")
{
    #region Nome de usuário.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.DuplicateUserName"/>.
    /// </summary>
    public string DuplicateUserName { get; init; } = username;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.InvalidUserName"/>.
    /// </summary>
    public string InvalidUserName { get; init; } = username;

    #endregion

    #region E-mail.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.DuplicateEmail"/>.
    /// </summary>
    public string DuplicateEmail { get; init; } = email;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.InvalidEmail"/>.
    /// </summary>
    public string InvalidEmail { get; init; } = email;

    #endregion

    #region Senha.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordMismatch"/>.
    /// </summary>
    public string PasswordMismatch { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordRequiresDigit"/>.
    /// </summary>
    public string PasswordRequiresDigit { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordRequiresLower"/>.
    /// </summary>
    public string PasswordRequiresLower { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordRequiresNonAlphanumeric"/>.
    /// </summary>
    public string PasswordRequiresNonAlphanumeric { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordRequiresUniqueChars"/>.
    /// </summary>
    public string PasswordRequiresUniqueChars { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordRequiresUpper"/>.
    /// </summary>
    public string PasswordRequiresUpper { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.PasswordTooShort"/>.
    /// </summary>
    public string PasswordTooShort { get; init; } = password;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.UserAlreadyHasPassword"/>.
    /// </summary>
    public string UserAlreadyHasPassword { get; init; } = password;

    #endregion

    #region Código.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.InvalidToken"/>.
    /// </summary>
    public string InvalidToken { get; init; } = code;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.RecoveryCodeRedemptionFailed"/>.
    /// </summary>
    public string RecoveryCodeRedemptionFailed { get; init; } = code;

    #endregion

    #region Função.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.DuplicateRoleName"/>.
    /// </summary>
    public string DuplicateRoleName { get; init; } = role;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.InvalidRoleName"/>.
    /// </summary>
    public string InvalidRoleName { get; init; } = role;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.UserAlreadyInRole"/>.
    /// </summary>
    public string UserAlreadyInRole { get; init; } = role;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.UserNotInRole"/>.
    /// </summary>
    public string UserNotInRole { get; init; } = role;

    #endregion

    #region Outro.

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.ConcurrencyFailure"/>.
    /// </summary>
    public string ConcurrencyFailure { get; init; } = other;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.DefaultError"/>.
    /// </summary>
    public string DefaultError { get; init; } = other;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.LoginAlreadyAssociated"/>.
    /// </summary>
    public string LoginAlreadyAssociated { get; init; } = other;

    /// <summary>
    /// Obtém ou inicializa o nome da propriedade de <see cref="IdentityErrorDescriber.UserLockoutNotEnabled"/>.
    /// </summary>
    public string UserLockoutNotEnabled { get; init; } = other;

    #endregion
}
