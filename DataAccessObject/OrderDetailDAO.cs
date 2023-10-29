using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

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

        public OrderDetail? GetById(int id)
        {
            using (var db = new BirdCageShopContext())
            {
                return db.OrderDetails.Where(od => od.OrderDetailId == id).AsNoTracking().FirstOrDefault();
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

        public bool AddNewOrderDetail(OrderDetail newEntity)
        {
            using var db = new BirdCageShopContext();
            db.OrderDetails.Add(newEntity);
            return db.SaveChanges() > 0;
        }

        public bool UpdateOrderDetail(OrderDetail updateEntity)
        {
            using var db = new BirdCageShopContext();
            db.Update(updateEntity);
            return db.SaveChanges() > 0;
        }
    }
}
