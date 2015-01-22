using Abp.Application.Navigation;
using Abp.Localization;

namespace Stilago.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class StilagoNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", StilagoConsts.LocalizationSourceName),
                        url: "#/search/",
                        icon: "mdi-action-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "CreateComputer",
                        new LocalizableString("CreateComputer", StilagoConsts.LocalizationSourceName),
                        url: "#/Computer/Create",
                        icon: "mdi-content-add"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "EditComputer",
                        new LocalizableString("CreateComputer", StilagoConsts.LocalizationSourceName),
                        url: "#/Computer/Edit/:id",
                        icon: "mdi-action-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "PreviewComputer",
                        new LocalizableString("PreviewComputer", StilagoConsts.LocalizationSourceName),
                        url: "#/Computer/preview/:id",
                        icon: "mdi-action-visibility"
                        )
                );
        }
    }
}
