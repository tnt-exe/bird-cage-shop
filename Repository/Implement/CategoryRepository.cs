using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
