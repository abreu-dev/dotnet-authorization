using System.ComponentModel.DataAnnotations;

namespace Autho.Infra.Data.Enums
{
    public enum Permission
    {
        [Display(Name = "PermissionWebAccess", Description = "web-access")]
        WebAccess = 0,

        [Display(Name = "PermissionMobileAccess", Description = "mobile-access")]
        MobileAccess = 1
    }
}
