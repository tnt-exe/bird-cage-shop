using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> categoriesList = CategoryDAO.SingletonInstance.GetAllCategories();
            return _mapper.Map<List<CategoryDTO>>(categoriesList);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            Category category = CategoryDAO.SingletonInstance.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public bool AddCategory(CategoryDTO category)
        {
            Category categoryModel = _mapper.Map<Category>(category);
            return CategoryDAO.SingletonInstance.AddCategory(categoryModel);
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            Category categoryModel = _mapper.Map<Category>(category);
            return CategoryDAO.SingletonInstance.UpdateCategory(categoryModel);
        }

        public bool DeleteCategory(int id)
        {
            return CategoryDAO.SingletonInstance.DeleteCategory(id);
        }
    }
}
