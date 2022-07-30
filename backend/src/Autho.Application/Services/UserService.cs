using Autho.Application.Contracts.User;
using Autho.Application.Interfaces;
using Autho.Domain.Entities;
using Autho.Domain.Interfaces;
using AutoMapper;

namespace Autho.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task AddUser(UserCreationDto creationDto)
        {
            var newUser = new UserDomain(creationDto.Name, creationDto.Email, creationDto.Login, creationDto.Password);

            _userRepository.Add(newUser);
            _userRepository.UnitOfWork.Complete();

            return Task.CompletedTask;
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            var users = _userRepository.GetAllUsers();
            return Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(users));
        }
    }
}
