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

        public List<CageImage> GetCageImages(int cageId)
        {
            List<CageImage> cageImages = null;
            try
            {
                using var db = new BirdCageShopContext();
                cageImages = db.CageImages.Where(image => image.CageId == cageId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cageImages;
        }

        public bool AddCageImage(CageImage cageImg)
        {
            bool result;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    db.CageImages.Add(cageImg);
                    result = db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
            return result;
        }

        public bool DeleteCageImage(int cageImgId)
        {
            bool result;

            return false;
        }

        public bool UpdateCageImage(CageImage cageImg)
        {
            bool result = false;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    CageImage cageObj = db.CageImages.Find(cageImg.CageImageId);
                    if (cageObj != null)
                    {
                        db.Entry(cageObj).CurrentValues.SetValues(cageImg);
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

        public bool ChangeCageImgStatus(int cageImgId, int status)
        {
            bool result;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    CageImage cageObj = db.CageImages
                        .Where(image => image.CageImageId == cageImgId)
                        .FirstOrDefault();
                    cageObj.Status = status;
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
