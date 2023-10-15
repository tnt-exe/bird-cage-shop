namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            Cages = new HashSet<Cage>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Cage> Cages { get; set; }
    }
}
