using System;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.FormSample.Web
{
    public partial class App
    {
        [Inject] private NavigationManager NavManager { get; set; }
        
        [JSInvokable("NotifyError")]
        public static void NotifyError(string error)
        {
            Console.WriteLine(error);
        }
    }
}