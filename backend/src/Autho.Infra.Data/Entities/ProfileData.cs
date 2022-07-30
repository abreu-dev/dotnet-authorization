using Autho.Infra.Data.Entities.Base;

namespace Autho.Infra.Data.Entities
{
    public class ProfileData : BaseData
    {
        public static string TableName => "Profile";

        public string Name { get; set; }
        public static int NameMaxLength => 15;

        public virtual ICollection<UserProfileData> Users { get; set; }
        public virtual ICollection<ProfilePermissionData> Permissions { get; set; }
    }
}
