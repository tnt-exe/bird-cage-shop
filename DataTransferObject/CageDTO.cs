using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class CageDTO
    {
        public int CageId { get; set; }

        [Required]
        public string? CageName { get; set; }
        public int? Status { get; set; }

        public decimal? CagePrice { get; set; }

        [Required]
        public int? Height { get; set; }
        [Required]
        public int? Radius { get; set; }

        [Required]
        public int? CageWeight { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string? ImageUrl { get; set; }

        public CategoryDTO? Category { get; set; }

        public ICollection<CageComponentDTO> CageComponents { get; set; } = new List<CageComponentDTO>();

        /*public CageDTO()
        {
        }

        public CageDTO(
            int cageId,
            string? cageName,
            string? status,
            decimal? cagePrice,
            int? cageSize,
            int? cageWeight,
            string? description,
            int? userId,
            int? categoryId
            )
        {
            CageId = cageId;
            CageName = cageName;
            Status = status;
            CagePrice = cagePrice;
            CageSize = cageSize;
            CageWeight = cageWeight;
            Description = description;
            UserId = userId;
            CategoryId = categoryId;
        }*/
    }
}
