namespace BusinessObject.Models
{
    public partial class CageImage
    {
        public int CageImageId { get; set; }
        public int? CageId { get; set; }
        public string? ImageUrl { get; set; }
        public int? Status { get; set; }

        public virtual Cage? Cage { get; set; }
    }
}
