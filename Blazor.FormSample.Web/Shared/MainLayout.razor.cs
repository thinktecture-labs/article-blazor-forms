using System.Threading.Tasks;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Blazor.FormSample.Web.Shared
{
    public partial class MainLayout
    {
        private bool _isDarkEnabled;
        private MudTheme _currentTheme = new();
        private bool _open = false;
        private bool preserveOpenState = false;
        private Breakpoint breakpoint = Breakpoint.Lg;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private readonly MudTheme _defaultTheme = new()
        {
            Palette = new Palette()
            {
                Black = "#272c34",
                AppbarBackground = "#ff584f",
                ActionDefault = "#ff584f",
                Primary = "#ff584f",
                Secondary = "#3d6fb4"
            }
        };

        private readonly MudTheme _darkTheme = new()
        {
            Palette = new Palette()
            {
                Primary = "#3d6fb4",
                Secondary = "#ff584f",
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                DrawerBackground = "#27272f",
                DrawerText = "rgba(255,255,255, 0.50)",
                DrawerIcon = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "#fff",
                TextSecondary = "#fff",
                ActionDefault = "#adadb1",
                ActionDisabled = "rgba(255,255,255, 0.26)",
                ActionDisabledBackground = "rgba(255,255,255, 0.12)"
            }
        };


        protected override void OnInitialized()
        {
            _currentTheme = _defaultTheme;
        }

        private void ToggleDrawer()
        {
            _open = !_open;
        }

        private void DarkMode()
        {
            _isDarkEnabled = !_isDarkEnabled;
            _currentTheme = _currentTheme == _defaultTheme ? _darkTheme : _defaultTheme;
        }
    }
}