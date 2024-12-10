using ProjectName.Core.Models;
using ProjectName.DAL;

namespace On_call_masters.BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
        }
