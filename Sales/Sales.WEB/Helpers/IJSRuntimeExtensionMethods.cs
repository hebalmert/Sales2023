using System;
using Microsoft.JSInterop;

namespace Sales.WEB.Helpers
{
	public static class IJSRuntimeExtensionMethods
    { 
        //Para cuando nos logueamos
        public static ValueTask<object> SetLocalStorage(this IJSRuntime js, string key, string content)
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, content);
        }

        //Para llamar el Storae y recuperar el Token
        public static ValueTask<object> GetLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.getItem", key);
        }

        //Remover el Token
        public static ValueTask<object> RemoveLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }

    }
}

