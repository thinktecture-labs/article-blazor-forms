using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Services
{
    public interface IFormsService
    {
        RenderFragment CreateComponent<T>(T data, EditContext context);
    }
}