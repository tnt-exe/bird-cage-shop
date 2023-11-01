using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ChangeUserStatus(int userId, int userStatus)
        {
            return UserDAO.SingletonInstance.ChangeUserStatus(userId, userStatus);
        }

        public List<UserDTO> GetAllUsers()
        {
            List<User> users = UserDAO.SingletonInstance.Users;
            if (users == null)
            {
                return null;
            }
            return _mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO GetUserById(int id)
        {
            User user = UserDAO.SingletonInstance.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(user);
        }

        public bool IsEmailExisted(string email)
        {
            return UserDAO.SingletonInstance.IsEmailExisted(email);
        }

        public bool IsPhoneExisted(string phone)
        {
            return UserDAO.SingletonInstance.IsPhoneExisted(phone);
        }

        public UserDTO Login(string email, string pwd)
        {
            User loginedUser = UserDAO.SingletonInstance.GetUser(email, pwd);
            if (loginedUser == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(loginedUser);
        }

        public bool Register(UserDTO userDTO)
        {
            User newUser = _mapper.Map<User>(userDTO);
            return UserDAO.SingletonInstance.AddUser(newUser);
        }

        public bool UpdateUserEmailPassword(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            return UserDAO.SingletonInstance.UpdateUserEmailPassword(user);
        }

        public bool UpdateUserInformation(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            return UserDAO.SingletonInstance.UpdateUserInfo(user);
        }
    }
}
