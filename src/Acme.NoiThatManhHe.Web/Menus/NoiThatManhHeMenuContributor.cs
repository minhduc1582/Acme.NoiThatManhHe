using System.Threading.Tasks;
using Acme.NoiThatManhHe.Localization;
using Acme.NoiThatManhHe.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.NoiThatManhHe.Web.Menus;

public class NoiThatManhHeMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        if (!MultiTenancyConsts.IsEnabled)
        {
            var administration = context.Menu.GetAdministration();
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }


        context.Menu.Items.Insert(0, new ApplicationMenuItem("Products.Home", "Home", "~/"));

        var bookStoreMenu = new ApplicationMenuItem(
            "Products",
            "Products",
            icon: "fa fa-cart-arrow-down",
            url: "/Products"
        );
        var projectStoreMenu = new ApplicationMenuItem(
           "Projects",
           "Projects",
           icon: "fa fa-briefcase",
           url: "/Projects"
       );
        var designStoreMenu = new ApplicationMenuItem(
           "DesignTypes",
           "DesignTypes",
           icon: "fa fa-briefcase",
           url: "/DesignTypes"
       );

        context.Menu.AddItem(bookStoreMenu);
        context.Menu.AddItem(designStoreMenu);
        context.Menu.AddItem(projectStoreMenu);

        //bookStoreMenu.AddItem(new ApplicationMenuItem(
        //    "Products.Product",
        //    "Products",
        //    url: "/Products"
        //));

    }
}
