using BusinessObject.Models;

namespace DataAccessObject
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderDetailDAO();
                    }
                    return _instance;
                }
            }
        }

        public List<OrderDetail> GetAll(int orderId)
        {
            List<OrderDetail> detailList;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    detailList = db.OrderDetails
                        .Where(od => od.OrderId == orderId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return detailList;
        }
    }
}
