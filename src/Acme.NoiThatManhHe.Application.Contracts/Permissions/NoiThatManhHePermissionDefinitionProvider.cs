using Acme.NoiThatManhHe.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.NoiThatManhHe.Permissions;

public class NoiThatManhHePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NoiThatManhHePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NoiThatManhHePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NoiThatManhHeResource>(name);
    }
}
