using Autho.Infra.Data.Entities.Base;

namespace Autho.Infra.Data.Entities
{
    public class ProfilePermissionData : BaseData
    {
        public static string TableName => "ProfilePermission";

        public Guid ProfileId { get; set; }
        public ProfileData Profile { get; set; }

        public Guid PermissionId { get; set; }
        public PermissionData Permission { get; set; }
    }
}
