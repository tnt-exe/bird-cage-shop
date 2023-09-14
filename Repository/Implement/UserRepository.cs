using AutoMapper;
using DataTransferObject;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ChangeUserStatus(int userId, int userstatus)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailExisted(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsPhoneExisted(string phone)
        {
            throw new NotImplementedException();
        }

        public UserDTO Login(string email, string pwd)
        {
            throw new NotImplementedException();
        }

        public bool Register(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
