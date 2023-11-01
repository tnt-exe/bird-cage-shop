using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class ComponentDTO
    {
        public int ComponentId { get; set; }

        [Required]
        public string? ComponentName { get; set; }

        [Required]
        public decimal? ComponentPrice { get; set; }

        public bool Required { get; set; } = false;
        public int QuantityRequired { get; set; } = 0;

        public ComponentDTO()
        {
        }

        public ComponentDTO(int componentId, string? componentName, decimal? componentPrice)
        {
            ComponentId = componentId;
            ComponentName = componentName;
            ComponentPrice = componentPrice;
        }
    }
}
