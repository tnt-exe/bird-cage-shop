namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Role { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
