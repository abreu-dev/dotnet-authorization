using Autho.Application.Contracts.User;

namespace Autho.Application.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserCreationDto creationDto);

        Task<IEnumerable<UserDto>> GetAll();
    }
}
