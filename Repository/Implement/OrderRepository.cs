using AutoMapper;
using DataTransferObject;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ChangeOrderStatus(int orderId, int orderstatus)
        {
            throw new NotImplementedException();
        }

        public OrderDTO CreateOrder(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> GetOrderByUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> GetOrderListByStatus(int orderstatus)
        {
            throw new NotImplementedException();
        }

        public bool Reorder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
