using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO
    {
        private static CategoryDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CategoryDAO();
                    }
                    return _instance;
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoriesList;
            try
            {
                using var db = new BirdCageShopContext();
                categoriesList = db.Categories.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categoriesList;
        }

        public Category GetCategoryById(int id)
        {
            Category category;
            try
            {
                using var db = new BirdCageShopContext();
                category = db.Categories.SingleOrDefault(c => c.CategoryId == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
    }
}
