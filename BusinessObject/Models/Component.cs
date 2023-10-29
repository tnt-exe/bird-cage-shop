namespace BusinessObject.Models
{
    public partial class Component
    {
        public Component()
        {
            CageComponents = new HashSet<CageComponent>();
        }

        public int ComponentId { get; set; }
        public string? ComponentName { get; set; }
        public decimal? ComponentPrice { get; set; }

        public virtual ICollection<CageComponent> CageComponents { get; set; }
    }
}
