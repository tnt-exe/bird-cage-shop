using BusinessObject.Models;

namespace DataAccessObject
{
    public class CageImageDAO
    {
        private static CageImageDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private CageImageDAO() { }
        public static CageImageDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageImageDAO();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<CageImage> GetCageImages(int cageId)
        {
            IEnumerable<CageImage> cageImages = null;
            try
            {
                using var db = new BirdCageShopContext();
                cageImages = db.CageImages.Where(ci => ci.CageId == cageId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cageImages;
        }
    }
}
