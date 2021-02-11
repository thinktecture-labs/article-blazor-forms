using Blazor.FormSample.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.FormSample.Web.Components
{
    public partial class PersonInfoCard
    {
        [Parameter] public Person Person { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> PersonClicked { get; set; }
    }
}