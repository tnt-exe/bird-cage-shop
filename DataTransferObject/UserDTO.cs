using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Role { get; set; }
        public int? Status { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(
            int userId,
            string? fullName,
            string? email,
            string? password,
            string? phone,
            DateTime? dob,
            bool? gender,
            string? address,
            string? avatarUrl,
            string? role,
            int? status
            )
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Password = password;
            Phone = phone;
            Dob = dob;
            Gender = gender;
            Address = address;
            AvatarUrl = avatarUrl;
            Role = role;
            Status = status;
        }
    }
}
