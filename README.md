# StarterDotNet

StarterDotNet é uma biblioteca que fornece utilitários para projetos .NET.

## Índice

- [ASP.NET Core Identity](#aspnet-core-identity)
- [Autores](#autores)
- [Notas de lançamento](#notas-de-lançamento)
- [Licença](#licença)

## ASP.NET Core Identity

Você pode usar a extensão `GetPropertyName()` para ajudá-lo em validações de erros do ASP.NET Core Identity.

Ele é útil quando você usa um modelo de validação que relaciona o nome da propriedade com o erro, como
**DataAnnotation** ou **FluentValidation**.

``` csharp
IdentityResult result = await UserManager.CreateAsync(user, _input.Password);

if (!result.Suceeded)
{
    // Neste caso os erros de nome de usuário terão o nome da propriedade como "Email".
    // 
    // As propriedades já tem nomes definidos por padrão que são comumente usados, como os erros de e-mail, que terão
    // o nome da propriedade como "Email" a menos que você mude, assim como acontece abaixo com os erros de nome de
    // usuário.
    var propertyNames = new IdentityErrorPropertiesName(username: nameof(_input.Email));

    foreach (IdentityError error in result.Errors)
    {
        string propertyName = error.GetPropertyName(propertyNames);

        ModelState.AddModelError(propertyName, error.Description);
    }
}
```

## Autores

- [KempDec](https://github.com/kempdec) - Mantedora do projeto de código aberto.
- [Vinícius Lima](https://github.com/viniciusxdl) - Desenvolvedor .NET C#.

## Notas de lançamento

Para notas de lançamento, confira a [seção de releases do StarterDotNet](https://github.com/kempdec/StarterDotNet/releases).

## Licença

[MIT](https://github.com/kempdec/StarterDotNet/blob/main/LICENSE)
