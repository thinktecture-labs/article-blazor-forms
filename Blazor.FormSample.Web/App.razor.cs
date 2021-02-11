using System;
using Microsoft.JSInterop;

namespace Blazor.FormSample.Web
{
    public partial class App
    {
        [JSInvokable("NotifyError")]
        public static void NotifyError(string error)
        {
            Console.WriteLine(error);
        }
    }
}