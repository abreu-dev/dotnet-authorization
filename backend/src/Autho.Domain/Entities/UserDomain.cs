using Autho.Domain.Entities.Base;

namespace Autho.Domain.Entities
{
    public class UserDomain : BaseDomain
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public virtual ICollection<ProfileDomain> Profiles { get; private set; }

        public UserDomain() { }

        public UserDomain(string name, string email, string login, string password)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Profiles = new List<ProfileDomain>();
        }

        public void AddProfiles(ICollection<ProfileDomain> profiles)
        {
            profiles.ToList().ForEach(profile =>
            {
                AddProfile(profile);
            });
        }

        public void AddProfile(ProfileDomain profile)
        {
            if (!ProfileExists(profile))
            {
                Profiles.Add(profile);
            }
        }

        public bool ProfileExists(ProfileDomain profile)
        {
            return Profiles.Any(x => x.Name == profile.Name);
        }
    }
}
