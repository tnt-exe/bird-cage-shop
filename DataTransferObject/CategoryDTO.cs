namespace DataTransferObject
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Status { get; set; }

        public CategoryDTO()
        {
        }

        public CategoryDTO(int categoryId, string? categoryName, int? status)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Status = status;
        }
    }
}
