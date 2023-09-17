using BusinessObject.Enums;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CageDAO
    {
        private static CageDAO _instance = null; 
        private static readonly object _instanceLock = new object();
        private CageDAO() { }
        public static CageDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageDAO();
                    }
                    return _instance;
                }
            }
        }

        public bool AddNewCage(Cage cage)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                db.Cages.Add(cage);
                result = db.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
            return result;
        }

        public bool ChangeCageStatus(Cage cageObj, int status)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                Cage cage = db.Cages.Where(c => c.CageId == cageObj.CageId).FirstOrDefault();
                cage.Status = status;
                result = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }

        public List<Cage> GetAllCages()
        {
            List<Cage> cages;
            try
            {
                using var db = new BirdCageShopContext();
                cages = db.Cages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cages;
        }

        public Cage GetCageById(int id)
        {
            Cage cage;
            try
            {
                using var db = new BirdCageShopContext();
                cage = db.Cages.Where(c => c.CageId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cage;
        }

        public List<Cage> GetCagesByCategory(int categoryId)
        {
            List<Cage> cages;
            try
            {
                using var db = new BirdCageShopContext();
                cages = db.Cages.Where(c => c.CategoryId == categoryId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cages;
        }

        public List<Cage> GetCagesByStatus(int status)
        {
            List<Cage> cages;
            try
            {
                using var db = new BirdCageShopContext();
                cages = db.Cages.Where(c => c.Status == status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cages;
        }

        public List<Cage> GetSearchCages(string keyword)
        {
            List<Cage> cages;
            try
            {
                using var db = new BirdCageShopContext();
                cages = db.Cages.Where(c => c.CageName.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cages;
        }

        public List<Cage> GetTopCages(int top)
        {
            List<Cage> cages;
            try
            {
                using var db = new BirdCageShopContext();
                cages = db.Cages
                    .Where(c => c.Status == (int)CageStatus.Available)
                    .OrderByDescending(c => c.CageId).Take(top)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cages;
        }

        public bool UpdateCage(Cage cageObj)
        {
            bool result = false;
            try
            {
                var cage = GetCageById(cageObj.CageId);
                if (cage != null)
                {
                    using var db = new BirdCageShopContext();
                    db.Entry(cage).CurrentValues.SetValues(cageObj);
                    result = db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }
    }
}
