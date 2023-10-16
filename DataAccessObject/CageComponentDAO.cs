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
    }
}
