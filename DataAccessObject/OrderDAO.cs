using BusinessObject.Enums;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

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

        public Order? GetOrderById(int id)
        {
            using (var db = new BirdCageShopContext())
            {
                return db.Orders
                    .Where(o => o.OrderId == id)
                    .Include(nameof(Order.OrderDetails) + "." + nameof(OrderDetail.Cage))
                    .AsNoTracking()
                    .FirstOrDefault();
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
                using (var db = new BirdCageShopContext())
                {
                    db.Add(order);
                    result = db.SaveChanges() > 0;
                }
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
            using var db = new BirdCageShopContext();
            return db.Orders.Where(o => o.User!.Email.Equals(email)).ToList();
        }

        public Order? GetSuiatbleOrder(int userId, int status)
        {
            using var db = new BirdCageShopContext();
            return db.Orders
                .Where(o => o.UserId == userId && o.Status == status)
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public bool UpdateOrder(Order updateOrder)
        {
            using var db = new BirdCageShopContext();
            db.Update(updateOrder);
            return db.SaveChanges() > 0;
        }

        public bool DeleteOrder(int orderId)
        {
            using var db = new BirdCageShopContext();
            var order = db.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
            if (order != null)
            {
                order.Status = (int)OrderStatus.Undefined;
                db.Orders.Update(order);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
