using Autho.Infra.Data.Entities.Base;

namespace Autho.Infra.Data.Entities
{
    public class UserData : BaseData
    {
        public static string TableName => "User";

        public string Name { get; set; }
        public static int NameMaxLength => 15;

        public string Email { get; set; }
        public static int EmailMaxLength => 15;

        public string Login { get; set; }
        public static int LoginMaxLength => 15;

        public string Password { get; set; }
        public static int PasswordMaxLength => 15;

        public virtual ICollection<UserProfileData> Profiles { get; set; }
    }
}
