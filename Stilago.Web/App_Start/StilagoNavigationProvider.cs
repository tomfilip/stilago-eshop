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
                        url: "#/",
                        icon: "mdi-action-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", StilagoConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "mdi-action-info"
                        )
                );
                //).AddItem(
                //    new MenuItemDefinition(
                //        "Search",
                //        new LocalizableString("Search", StilagoConsts.LocalizationSourceName),
                //        url: "#/search",
                //        icon: "hide"
                //        )
                //).AddItem(
                //    new MenuItemDefinition(
                //        "ShoppingCart",
                //        new LocalizableString("ShoppingCart", StilagoConsts.LocalizationSourceName),
                //        url: "#/Orders/shopping-cart",
                //        icon: "mdi-action-shopping-cart"
                //        )
                //).AddItem(
                //    new MenuItemDefinition(
                //        "MyOrders",
                //        new LocalizableString("MyOrders", StilagoConsts.LocalizationSourceName),
                //        url: "#/Orders/my-orders",
                //        icon: "mdi-action-shopping-basket"
                //        )
                //);
        }
    }
}
