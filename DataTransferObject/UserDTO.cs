using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
        public int? Status { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(int userId, string? fullName, string? email, DateTime? birthDate, bool? gender, string? address, string? avatarUrl, int? status)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Address = address;
            AvatarUrl = avatarUrl;
            Status = status;
        }
    }
}
