using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        UserDTO Login(string email, string pwd);
        bool Register(UserDTO user);
        bool Update(UserDTO user);
        bool ChangeUserStatus(int userId, int userstatus);
        bool IsEmailExisted(string email);
        bool IsPhoneExisted(string phone);
        UserDTO GetUserById(int id);
    }
}
