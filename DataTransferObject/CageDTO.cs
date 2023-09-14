using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CageDTO
    {
        public int CageId { get; set; }
        public int? CategoryId { get; set; }
        public string? CageName { get; set; }
        public int? Quantity { get; set; }
        public string? Material { get; set; }
        public int? Status { get; set; }
        public double? Price { get; set; }
        public string? Color { get; set; }
        public int? Rating { get; set; }
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public string? Description { get; set; }

        public CageDTO()
        {
        }

        public CageDTO(int cageId, int? categoryId, string? cageName, int? quantity, string? material, int? status, double? price, string? color, int? rating, int? size, int? weight, string? description)
        {
            CageId = cageId;
            CategoryId = categoryId;
            CageName = cageName;
            Quantity = quantity;
            Material = material;
            Status = status;
            Price = price;
            Color = color;
            Rating = rating;
            Size = size;
            Weight = weight;
            Description = description;
        }
    }
}
