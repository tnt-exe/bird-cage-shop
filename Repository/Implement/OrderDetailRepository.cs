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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;

        public OrderDetailRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<OrderDetailDTO> GetOrderDetail(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool InsertOrderDetail(OrderDetailDTO orderdetail)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrderDetail(OrderDetailDTO orderdetail)
        {
            throw new NotImplementedException();
        }
    }
}
