using KempDec.StarterDotNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace KempDec.StarterDotNet.Blazor;

/// <summary>
/// Adiciona um componente de validação para um formulário.
/// </summary>
/// <remarks>É necessário um parâmetro de cascata do tipo <see cref="EditContext"/>. Por exemplo, usar dentro de 
/// <see cref="EditForm"/>.</remarks>
public partial class FormValidator : ComponentBase
{
    /// <summary>
    /// Obtém ou inicializa o <see cref="EditContext"/> atual.
    /// </summary>
    [CascadingParameter]
    private EditContext? CurrentEditContext { get; init; }

    /// <summary>
    /// O responsável pela persistência das mensagens de validação do <see cref="CurrentEditContext"/>.
    /// </summary>
    private ValidationMessageStore? _validationMessageStore;

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
        {
            throw new InvalidOperationException($"É necessário ter um parâmetro de cascata do tipo " +
                $"{typeof(EditContext)}.");
        }

        _validationMessageStore = new ValidationMessageStore(CurrentEditContext);

        CurrentEditContext.OnFieldChanged += CurrentEditContext_OnFieldChanged;
        CurrentEditContext.OnValidationRequested += CurrentEditContext_OnValidationRequested;
    }

    /// <summary>
    /// Adiciona mensagens de validação a partir dos erros do sistema de identidade especificado.
    /// </summary>
    /// <param name="errors">Os erros do sistema de identidade.</param>
    public void Add(IEnumerable<IdentityError> errors) => Add(errors, new IdentityErrorPropertyNames());

    /// <summary>
    /// Adiciona uma mensagem de validação a partir do erro do sistema de identidade especificado.
    /// </summary>
    /// <param name="error">O erro do sistema de identidade.</param>
    public void Add(IdentityError error) => Add(error, new IdentityErrorPropertyNames());

    /// <summary>
    /// Adiciona mensagens de validação a partir dos erros do sistema de identidade especificado.
    /// </summary>
    /// <param name="errors">Os erros do sistema de identidade.</param>
    /// <param name="propertiesName">Os nomes das propriedades para os erros do sistema de identidade.</param>
    public void Add(IEnumerable<IdentityError> errors, IdentityErrorPropertyNames propertiesName)
    {
        foreach (IdentityError error in errors)
        {
            Add(error, propertiesName);
        }
    }

    /// <summary>
    /// Adiciona uma mensagem de validação a partir do erro do sistema de identidade especificado.
    /// </summary>
    /// <param name="error">O erro do sistema de identidade.</param>
    /// <param name="propertiesName">Os nomes das propriedades para os erros do sistema de identidade.</param>
    public void Add(IdentityError error, IdentityErrorPropertyNames propertiesName)
    {
        string fieldName = error.GetPropertyName(propertiesName);

        Add(fieldName, error.Description);
    }

    /// <summary>
    /// Adiciona uma mensagem de validação.
    /// </summary>
    /// <param name="fieldName">O nome do campo da mensagem de validação.</param>
    /// <param name="message">A mensagem de validação.</param>
    public void Add(string fieldName, string message)
    {
        if (CurrentEditContext is null || _validationMessageStore is null)
        {
            return;
        }

        FieldIdentifier field = CurrentEditContext.Field(fieldName);

        _validationMessageStore.Add(field, message);

        CurrentEditContext.NotifyValidationStateChanged();
    }

    /// <summary>
    /// Limpa todas as mensagens de validação.
    /// </summary>
    public void ClearAll()
    {
        if (CurrentEditContext is null || _validationMessageStore is null)
        {
            return;
        }

        _validationMessageStore.Clear();

        CurrentEditContext.NotifyValidationStateChanged();
    }

    /// <summary>
    /// Executa uma ação quando o valor de um campo é alterado.
    /// </summary>
    /// <param name="sender">A fonte do evento.</param>
    /// <param name="e">Um <see cref="EventArgs"/> que contém os dados do evento quando o valor de um campo é
    /// alterado.</param>
    private void CurrentEditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e) =>
        _validationMessageStore?.Clear(e.FieldIdentifier);

    /// <summary>
    /// Executa uma ação quando uma validação é solicitada.
    /// </summary>
    /// <param name="sender">A fonte do evento.</param>
    /// <param name="e">Um <see cref="EventArgs"/> que contém os dados do evento quando uma validação é
    /// solicitada.</param>
    private void CurrentEditContext_OnValidationRequested(object? sender, ValidationRequestedEventArgs e) =>
        _validationMessageStore?.Clear();

    /// <inheritdoc/>
    public void Dispose()
    {
        if (CurrentEditContext is null || _validationMessageStore is null)
        {
            return;
        }

        _validationMessageStore.Clear();

        CurrentEditContext.OnFieldChanged -= CurrentEditContext_OnFieldChanged;
        CurrentEditContext.OnValidationRequested -= CurrentEditContext_OnValidationRequested;
        CurrentEditContext.NotifyValidationStateChanged();
    }
}
