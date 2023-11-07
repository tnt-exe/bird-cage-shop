using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.Security.Claims;

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

        public IList<OrderDTO> Order { get; set; } = new List<OrderDTO>();

        public async Task OnGetAsync()
        {
            var email = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var role = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "scope")?.Value;

            if (new string("Customer").Equals(role))
            {
                Order = _orderRepository.GetOrderByUser(email ?? "")
                    .Where(o => o.Status != (int)OrderStatus.Undefined)
                    .ToList();
            }

            if (new string("Staff").Equals(role) || new string("Admin").Equals(role))
            {
                Order = _orderRepository.GetAllOrders()
                    .Where(o => o.Status != (int)OrderStatus.Waiting)
                    .ToList();
            }
        }

        public IActionResult OnGetDeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _orderRepository.DeleteOrder((int)id);

            if (result)
            {
                return RedirectToPage();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
