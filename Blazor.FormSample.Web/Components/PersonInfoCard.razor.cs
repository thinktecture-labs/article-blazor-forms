using Blazor.FormSample.Web.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.FormSample.Web.Components
{
    public partial class PersonInfoCard
    {
        [Parameter] public Person Person { get; set; }
    }
}