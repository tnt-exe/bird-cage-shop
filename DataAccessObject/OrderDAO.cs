using BusinessObject.Models;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private static OrderDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderDAO();
                    }
                    return _instance;
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders;
            try
            {
                using var db = new BirdCageShopContext();
                orders = db.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public bool ChangeOrderStatus(int orderId, int orderStatus)
        {
            bool result;
            try
            {
                using var db = new BirdCageShopContext();
                var order = db.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
                order.Status = orderStatus;
                result = db.SaveChanges() > 0;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool CreateOrder(Order order)
        {
            bool result;
            try
            {
                using var db = new BirdCageShopContext();
                db.Orders.Add(order);
                result = db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
            return result;
        }

        public List<Order> GetOrderListByStatus(int orderStatus)
        {
            List<Order> orderList;
            try
            {
                using var db = new BirdCageShopContext();
                orderList = db.Orders.Where(o => o.Status == orderStatus).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        public List<Order> GetOrderByUser(string email)
        {
            List<Order> orderList;
            try
            {
                using var db = new BirdCageShopContext();
                orderList = db.Users
                    .Where(u => u.Email == email)
                    .Join(db.Orders,
                        user => user.UserId, // Foreign key within Users table
                        order => order.UserId, // Foreign key within Orders table
                        (user, order) => order) // Result selector
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }
    }
}
