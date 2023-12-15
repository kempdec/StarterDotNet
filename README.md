# StarterDotNet

StarterDotNet é uma biblioteca que fornece utilitários para projetos .NET.

## Índice

- [Instalação](#instalação)
- [.NET Reflection](#net-reflection)
- [ASP.NET Core Identity](#aspnet-core-identity)
- [Blazor](#blazor)
    - [JSInterop](#jsinterop)
    - [StarterRenderMode](#starterrendermode)
- [Rotas do aplicativo](#rotas-do-aplicativo)
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

## .NET Reflection

### Instalação

Você pode optar por instalar apenas essa parte da biblioteca a partir do NuGet.

``` powershell
Install-Package KempDec.StarterDotNet.Reflection
```

### Como usar

Você pode usar os métodos de extensão do **StarterDotNet Reflection** para te ajudar ao usar Reflection do .NET.
Exemplo:

``` csharp
Assembly.GetExecutionAssembly()
    .GetAllClassesWithInterface<T>();
```

Você também pode usar `AssemblyHelper` para acessar os mesmos métodos de extensão do assembly de
`Assembly.GetCallingAssembly()`. Exemplo:

``` csharp
AssemblyHelper.GetAllClassesWithInterface<T>();
```

Os métodos de extensão disponíveis são:

``` csharp
// Obtém todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface especificado.
public static IEnumerable<T?> GetAllClassesWithInterface<T>(this Assembly assembly);

// Obtém todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface especificado.
public static IEnumerable<T?> GetAllClassesWithInterface<T>(this Assembly assembly, Type interfaceType);

// Obtém os tipos de todas as classes do assembly especificado, se houver alguma, que implemente o tipo da interface
especificado.
public static IEnumerable<Type> GetAllClassesWithInterface(this Assembly assembly, Type interfaceType);
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

## Blazor

### Instalação

**Essa parte da biblioteca deve ser instalada a parte e NÃO está disponível no pacote principal. Instale essa biblioteca
a partir do NuGet.**

``` powershell
Install-Package KempDec.StarterDotNet.Blazor
```

### Como usar

#### JSInterop

Você pode usar `StarterJSInterop` e `JSInteropBase` para facilitar a interopabilidade JavaScript do seu aplicativo e
executar funções JavaScript a partir do seu código C# no Blazor.

Para isso, crie um arquivo JavaScript contendo as funções que deseja usar com a interopabilidade. No exemplo abaixo o
arquivo está localizado em **js/app.js**.

**js/app.js**
``` javascript
// Função exportada que será invocada através do módulo.
export function sum(num1, num2)
{
    return num1 + num2;
}
```

Em seguida crie uma classe que herde `StarterJSInterop` ou `JSInteropBase` e importe o seu arquivo JavaScript que
deseja usar com a interopabilidade. O exemplo abaixo herda `StarterJSInterop` por já vir com alguns métodos
pré-construídos.

``` csharp
public class AppJSInterop : StarterJSInterop
{
    private readonly Task<IJSObjectReference> _moduleTask;

    public AppJSInterop(IJSRuntime js) : base(js) => _moduleTask = ImportModuleFileAsync(moduleFilePath: "js/app.js");

    // Interopabilidade com função "console.log" do JavaScript.
    public ValueTask ConsoleLogAsync(string message) => Runtime.InvokeVoidAsync("console.log", message);

    // Interopabilidade com a função "sum" do módulo, que foi exportada do arquivo JavaScript.
    public async ValueTask<int> SumAsync(int num1, int num2)
    {
        IJSObjectReference module = await _moduleTask;

        return await module.InvokeAsync<int>("sum", num1, num2);
    }
}
```

Adicione a injeção de dependência para `AppJSInterop` no seu arquivo `Program.cs`:

``` csharp
builder.Services.AddScoped<AppJSInterop>();
```

O uso seria semalhante ao exemplo abaixo:

``` csharp
public partial class Home
{
    [Inject]
    private AppJSInterop JS { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        int sumResult = await JS.SumAsync(num1: 1, num2: 2);

        await JS.ConsoleLogAsync(message: $"O resultado da soma é: {sumResult}.");
    }
}
```

Os métodos disponíveis para `StarterJSInterop` são:

``` csharp
// Foca em um elemento HTML, se houver algum, que possui o identificador especificado.
public ValueTask FocusOnElementIdAsync(string elementId);

// Registra a mensagem especificada no console.
public ValueTask ConsoleLogAsync(string message);

// Copia o texto especificado para a área de transferência.
public ValueTask<bool> CopyToClipboardAsync(string text);

// Abre uma nova janela ou guia do navegador com a URL especificada.
public ValueTask OpenAsync(string url);

// Abre uma nova janela ou guia do navegador com a URL especificada.
public ValueTask OpenAsync(string url, IBrowsingContext target);
```

#### StarterRenderMode

Use `StarterRenderMode` para definir a renderização interativamente no servidor por meio  da hospedagem do Blazor
Server sem pré-renderização do lado do servidor.

Em seu arquivo `_Imports.razor` adicione:

``` razor
@using static KempDec.StarterDotNet.Blazor.StarterRenderMode
```

E então defina o modo de renderização da seguinte maneira:

``` razor
@rendermode InteractiveServerWithoutPrerendering
```

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

## Autores

- [KempDec](https://github.com/kempdec) - Mantedora do projeto de código aberto.
- [Vinícius Lima](https://github.com/viniciusxdl) - Desenvolvedor .NET C#.

## Notas de lançamento

Para notas de lançamento, confira a [seção de releases do StarterDotNet](https://github.com/kempdec/StarterDotNet/releases).

## Licença

[MIT](https://github.com/kempdec/StarterDotNet/blob/main/LICENSE)
