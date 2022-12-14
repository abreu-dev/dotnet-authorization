using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using AutoMapper;

namespace Autho.Infra.Data.Seed
{
    public static class ProfileSeed
    {
        public static string AdministratorProfileName => "Administrator";

        public static void SeedData(IProfileRepository profileRepository, 
                                    IPermissionRepository permissionRepository, IMapper _mapper)
        {
            var existingProfile = profileRepository.GetByName(AdministratorProfileName);
            var permissions = permissionRepository.GetAll().ToList();

            if (existingProfile == null)
            {
                var newProfile = new ProfileDomain(AdministratorProfileName, permissions);
                profileRepository.Add(newProfile); 
            }
            else
            {
                existingProfile.AddPermissions(permissions);
            }

            profileRepository.UnitOfWork.Complete();
        }
    }
}
