using Autho.Infra.Data.Entities.Base;

namespace Autho.Infra.Data.Entities
{
    public class PermissionData : BaseData
    {
        public static string TableName => "Permission";

        public string Name { get; set; }
        public static int NameMaxLength => 100;

        public string Code { get; set; }
        public static int CodeMaxLength => 100;

        public virtual ICollection<ProfilePermissionData> Profiles { get; set; }
    }
}
