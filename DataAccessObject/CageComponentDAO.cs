using BusinessObject.Models;

namespace DataAccessObject
{
    public class CageComponentDAO
    {
        private static CageComponentDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private CageComponentDAO() { }
        public static CageComponentDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageComponentDAO();
                    }
                    return _instance;
                }
            }
        }
         
        public List<CageComponent> GetList()
        {
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    return db.CageComponents.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CageComponent GetCageComponentById(int id)
        {
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    return db.CageComponents.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CageComponent> GetCageComponents(int cageId)
        {
            List<CageComponent> cageComponentList = null;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    cageComponentList = db.CageComponents
                        .Where(component => component.CageId == cageId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cageComponentList;
        }

        public bool InsertCageComponent(List<CageComponent> cageComponentList)
        {
            bool result;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    foreach (var item in cageComponentList)
                    {
                        db.CageComponents.Add(item);
                    }

                    result = db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
            return result;
        }

        public bool UpdateCageComponent(CageComponent cageComponent)
        {
            bool result = false;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    CageComponent componentObj = db.CageComponents
                        .Find(cageComponent.ComponentId);
                    if (componentObj != null)
                    {
                        db.Entry(componentObj).CurrentValues.SetValues(cageComponent);
                        result = db.SaveChanges() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
            return result;
        }

        public bool DeleteCageComponent(int cageComponentId)
        {
            bool result;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    CageComponent componentObj = db.CageComponents
                        .Where(component => component.ComponentId == cageComponentId)
                        .FirstOrDefault();
                    db.Remove(componentObj);
                    result = db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
            return result;
        }
    }
}
