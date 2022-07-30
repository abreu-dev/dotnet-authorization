using Autho.Application.Contracts.Profile;

namespace Autho.Application.Contracts.User
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }

        public virtual ICollection<ProfileDto> Profiles { get; set; }
    }
}
