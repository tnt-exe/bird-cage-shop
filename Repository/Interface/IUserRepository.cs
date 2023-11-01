using DataTransferObject;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        UserDTO Login(string email, string pwd);
        bool Register(UserDTO userDTO);
        bool UpdateUserEmailPassword(UserDTO userDTO);
        bool UpdateUserInformation(UserDTO userDTO);
        bool ChangeUserStatus(int userId, int userstatus);
        bool IsEmailExisted(string email);
        bool IsPhoneExisted(string phone);
        UserDTO GetUserById(int id);
        List<UserDTO> GetAllUsers();
    }
}
