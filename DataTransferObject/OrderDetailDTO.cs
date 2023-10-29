namespace DataTransferObject
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? CageId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public CageDTO? Cage { get; set; }
    }
}
