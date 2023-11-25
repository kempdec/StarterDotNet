# StarterDotNet

StarterDotNet é uma biblioteca que fornece utilitários para projetos .NET.

## Índice

- [Instalação](#instalação)
- [Rotas do aplicativo](#rotas-do-aplicativo)
- [ASP.NET Core Identity](#aspnet-core-identity)
- [Autores](#autores)
- [Notas de lançamento](#notas-de-lançamento)
- [Licença](#licença)

## Instalação

Instale a biblioteca a partir do NuGet.

``` powershell
Install-Package KempDec.StarterDotNet
```

Esse pacote incluirá tudo do StarterDotNet, mas você pode optar por instalar
apenas uma parte dele. Para isso consulte a seção que deseja.

## Rotas do aplicativo

### Instalação

Você pode optar por instalar apenas essa parte da biblioteca a partir do NuGet.

``` powershell
Install-Package KempDec.StarterDotNet.AppRoutes
```

### Como usar

Você pode usar `IAppRoute` e `AppRouteBase` para ajudá-lo a usar as rotas do seu aplicativo.

Eles permitem que você pré-construa as rotas e depois apenas as usem de forma fácil e clara, definindo todos os
parâmetros que são necessários e facilitando a manutenção do código caso alguma regra na sua rota mude.

``` razor
@* Ao invés de: *@
<a href="/profile/@_profile.Id/orderhistory?status=@_orderStatus"></a>
<a href="/start?email=@_email"></a>
<a href="/start?email=@_email&redirectUrl=@_currentUrl"></a>

@* Use algo como: *@
<a href="@AppRoute.Profile.OrderHistory(_profile.Id, _orderStatus)"></a>
<a href="@AppRoute.Start(_email)"></a>
<a href="@AppRoute.Start(_email, _currentUrl)"></a>
```

Para isso, crie uma rota do aplicativo, de maneira semelhante a abaixo:

``` csharp
// Rota da página /start.
public sealed class StartAppRoute(string? email = null, string? redirectUrl = null) : AppRouteBase("/start")
{
    protected override Dictionary<string, string?> Params { get; } = new()
    {
        { "email", email },
        { "redirectUrl", redirectUrl }
    };
}

// Rota da página /profile/{profileId}/orderhistory.
public sealed class OrderHistoryAppRoute(int profileId, OrderStatusType? orderStatus = null)
    : AppRouteBase($"/profile/{profileId}/orderhistory")
{
    protected override Dictionary<string, string?> Params { get; } = new()
    {
        { "status", orderStatus?.ToString() }
    };
}

// Conjunto de rotas para /profile.
public sealed class ProfilesAppRoute
{
    public OrderHistoryAppRoute OrderHistory(int profileId, OrderStatusType? orderStatus = null) =>
        new(profileId, orderStatus);
}
```

E então pré-construa as rotas em uma classe estática:

``` csharp
public static class AppRoute
{
    // Rotas para /profile.
    public static ProfilesAppRoute Profile { get; } = new();

    // Rota /start.
    public static StartAppRoute Start(string? email = null) => new(email);
}
```

## ASP.NET Core Identity

### Instalação

Você pode optar por instalar apenas essa parte da biblioteca a partir do NuGet.

``` powershell
Install-Package KempDec.StarterDotNet.Identity
```

### Como usar

Você pode usar a extensão `GetPropertyName()` para ajudá-lo em validações de erros do ASP.NET Core Identity.

Ele é útil quando você usa um modelo de validação que relaciona o nome da propriedade com o erro, como
**DataAnnotation** ou **FluentValidation**.

``` csharp
IdentityResult result = await UserManager.CreateAsync(user, _input.Password);

if (!result.Suceeded)
{
    // Neste caso os erros de nome de usuário terão o nome da propriedade como "Email".
    // 
    // As propriedades já tem nomes definidos por padrão que são comumente usados, como os erros de e-mail,
    // que terão o nome da propriedade como "Email" a menos que você mude, assim como acontece abaixo com os
    // erros de nome de usuário.
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
