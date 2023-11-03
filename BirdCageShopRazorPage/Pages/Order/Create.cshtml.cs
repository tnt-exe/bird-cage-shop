using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.Security.Claims;

namespace BirdCageShopRazorPage.Pages.Order
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public CreateModel(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public IActionResult OnGet()
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var policyCheck = await _authorizationService.AuthorizeAsync(User, "Customer");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }

            var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var check = int.TryParse(userId, out var id);
            if (check)
            {
                var newOrder = new OrderDTO
                {
                    UserId = id,
                    OrderDate = DateTime.Now,
                    Status = (int)BusinessObject.Enums.OrderStatus.Waiting,
                    TotalPrice = 0
                };
                var result = _orderRepository.CreateOrder(newOrder);
                if (result)
                {
                    TempData["notification"] = "Tạo mới giỏ hàng thành công";
                    return RedirectToPage("./Index");
                }
            }
            TempData["notification"] = "Tạo mới giỏ hàng thất bại";
            return RedirectToPage("./Index");
        }
    }
}
