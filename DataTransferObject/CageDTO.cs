using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class CageDTO
    {
        public int CageId { get; set; }

        [Required]
        public string? CageName { get; set; }
        public int? Status { get; set; }

        [Required]
        public decimal? CagePrice { get; set; }

        [Required]
        public int? CageSize { get; set; }

        [Required]
        public int? CageWeight { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public CageDTO()
        {
        }

        public CageDTO(
            int cageId,
            string? cageName,
            int? status,
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
        }
    }
}
