using System;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sales.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            //Para hacer una prueba de Retardo
            await Task.Delay(3000);

            var anonimous = new ClaimsIdentity();
            var HebertUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("FirstName", "Hebert"),
            new Claim("LastName", "Merchan"),
            new Claim(ClaimTypes.Name, "merchanhebert@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")

        },
                authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(HebertUser)));
        }
    }

}

