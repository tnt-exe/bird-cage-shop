using DataTransferObject;

namespace Repository.Interface
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
        bool AddCategory(CategoryDTO category);
        bool UpdateCategory(CategoryDTO category);
        bool DeleteCategory(int id);
    }
}
