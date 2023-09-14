using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CageImageDTO
    {
        public int CageImageId { get; set; }
        public int? CageId { get; set; }
        public string? ImageUrl { get; set; }
        public int? Status { get; set; }

        public CageImageDTO()
        {
        }

        public CageImageDTO(int cageImageId, int? cageId, string? imageUrl, int? status)
        {
            CageImageId = cageImageId;
            CageId = cageId;
            ImageUrl = imageUrl;
            Status = status;
        }
    }
}
