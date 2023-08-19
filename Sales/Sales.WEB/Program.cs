using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sales.WEB;
using Sales.WEB.Auth;
using Sales.WEB.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7150/") });

//Para Mantener el sistema de Validacion de Usuarios
builder.Services.AddAuthorizationCore();

//era solo para hacer prueas de usuario Manual
//builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();


//Sistema usar el Proveedor de Autenticacion
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());


//Injectamos la Interfaz y su Clase
builder.Services.AddScoped<IRepository, Repository>();

//Injection SweetAlert2
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();

