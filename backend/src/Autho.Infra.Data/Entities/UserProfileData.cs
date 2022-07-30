using Autho.Infra.Data.Entities.Base;

namespace Autho.Infra.Data.Entities
{
    public class UserProfileData : BaseData
    {
        public static string TableName => "UserProfile";

        public Guid UserId { get; set; }
        public UserData User { get; set; }

        public Guid ProfileId { get; set; }
        public ProfileData Profile { get; set; }
    }
}
