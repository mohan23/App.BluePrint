using Abp.Application.Navigation;
using Abp.Localization;

namespace App.BluePrint.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class BluePrintNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Dashboard",
                        new LocalizableString("Dashboard", Consts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Process",
                        new LocalizableString("Process", Consts.LocalizationSourceName),
                        url: "#/process",
                        icon: "fa fa-tasks"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Search",
                        new LocalizableString("Search", Consts.LocalizationSourceName),
                        url: "#/search",
                        icon: "fa fa-search"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Administration",
                        new LocalizableString("Administration", Consts.LocalizationSourceName),
                        url: "#/admin",
                        icon: "fa fa-gears"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Insights",
                        new LocalizableString("Insights", Consts.LocalizationSourceName),
                        url: "#/insights",
                        icon: "fa fa-line-chart"
                        )
                );
        }
    }
}
