using Autho.Domain.Entities;
using Autho.Domain.Interfaces;

namespace Autho.Infra.Data.Seed
{
    public static class UserSeed
    {
        public static string AdministratorName => "Administrator";
        public static string AdministratorEmail => "admin@gmail.com";
        public static string AdministratorLogin => "admin";
        public static string AdministratorPassword => "admin@123";

        public static void SeedData(IUserRepository userRepository,
                                    IProfileRepository profileRepository)
        {
            var existingUser = userRepository.GetByName(AdministratorName);
            var adminProfile = profileRepository.GetByName(ProfileSeed.AdministratorProfileName);

            if (existingUser == null)
            {
                var newUser = new UserDomain(AdministratorName, AdministratorEmail, AdministratorLogin, AdministratorPassword);
                newUser.AddProfile(adminProfile);
                userRepository.Add(newUser);
            }
            else
            {
                existingUser.AddProfile(adminProfile);
                userRepository.Update(existingUser);
            }

            userRepository.UnitOfWork.Complete();
        }
    }
}
