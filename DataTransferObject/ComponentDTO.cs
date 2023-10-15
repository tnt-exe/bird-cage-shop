namespace DataTransferObject
{
    public class ComponentDTO
    {
        public int ComponentId { get; set; }
        public string? ComponentName { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public decimal? ComponentPrice { get; set; }

        public ComponentDTO()
        {
        }

        public ComponentDTO(int componentId, string? componentName, string? color, string? material, decimal? componentPrice)
        {
            ComponentId = componentId;
            ComponentName = componentName;
            Color = color;
            Material = material;
            ComponentPrice = componentPrice;
        }
    }
}
