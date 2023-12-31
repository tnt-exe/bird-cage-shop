﻿using BusinessObject.Models;

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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                using var db = new BirdCageShopContext();
                db.Categories.Add(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                using var db = new BirdCageShopContext();
                db.Categories.Update(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                using var db = new BirdCageShopContext();
                var category = db.Categories.SingleOrDefault(c => c.CategoryId == id);
                category.Status = 0;
                db.Categories.Update(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
