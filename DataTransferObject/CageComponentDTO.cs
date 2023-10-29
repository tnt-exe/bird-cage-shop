namespace DataTransferObject
{
    public class CageComponentDTO
    {
        public int CageComponentId { get; set; }
        public int? ComponentId { get; set; }
        public int? CageId { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public ComponentDTO? Component { get; set; }

        public CageComponentDTO()
        {
        }

        public CageComponentDTO(int cageComponentId, int? componentId, int? cageId, int? quantity, decimal? price)
        {
            CageComponentId = cageComponentId;
            ComponentId = componentId;
            CageId = cageId;
            Quantity = quantity;
            Price = price;
        }
    }
}
