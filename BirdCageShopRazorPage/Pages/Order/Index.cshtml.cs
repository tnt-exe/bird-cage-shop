using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderRepository _orderRepository;

        public IndexModel(IHttpContextAccessor httpContextAccessor, IOrderRepository orderRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderRepository = orderRepository;
        }

        public IList<OrderDTO> Order { get;set; } = new List<OrderDTO>();

        public async Task OnGetAsync()
        {
            var email = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var role = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "scope")?.Value;

            if(new string("Customer").Equals(role))
            {
                Order = _orderRepository.GetOrderByUser(email ?? "");
            }

            if(new string("Staff").Equals(role) || new string("Admin").Equals(role))
            {
                Order = _orderRepository.GetAllOrders();
            }
        }
    }
}
