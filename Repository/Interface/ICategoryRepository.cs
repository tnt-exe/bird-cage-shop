using DataTransferObject;

namespace Repository.Interface
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
    }
}
