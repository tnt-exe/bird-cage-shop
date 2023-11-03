using BusinessObject.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;
using System.Security.Claims;

namespace BirdCageShopRazorPage.Pages.Cage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICageRepository _cageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateModel(ICageRepository cageRepository,
            ICategoryRepository categoryRepository,
            IComponentRepository componentRepository,
            IAuthorizationService authorizationService,
            IHttpContextAccessor httpContextAccessor,
            IOrderRepository orderRepository)
        {
            _cageRepository = cageRepository;
            _categoryRepository = categoryRepository;
            _componentRepository = componentRepository;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            var policyCheck = await _authorizationService.AuthorizeAsync(User, "Customer");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }

            Components = _componentRepository.GetAllComponent();

            ViewData["CageStatus"] = new SelectList(
                new cageStatus[] 
                { 
                    new cageStatus("Unavailable", 0),
                    new cageStatus("Available", 1)
                },
                "intStatus", "stringStatus"
            );
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public int Quantity { get; set; } = 0;

        [BindProperty]
        public CageDTO Cage { get; set; } = default!;

        [BindProperty]
        public List<CageComponentDTO> CageComponents { get; set; } = new();
        [BindProperty]
        public List<ComponentDTO> Components { get; set; } = new();

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
                Cage.UserId = id;
                Cage.CageComponents = CageComponents;

                if (Cage.Status == (int)BusinessObject.Enums.CageStatus.Custom)
                {
                    // Create new order with that cage
                    OrderDTO newOrder = new OrderDTO
                    {
                        UserId = id,
                        Status = (int)BusinessObject.Enums.OrderStatus.Custom,
                        OrderDate = DateTime.Now,
                        PaymentStatus = (int)BusinessObject.Enums.PaymentStatus.Unpaid
                    };

                    OrderDetailDTO orderDetail = new OrderDetailDTO()
                    {
                        Quantity = Quantity
                    };

                    orderDetail.Order = newOrder;
                    //newOrder.OrderDetails = new List<OrderDetailDTO>() { orderDetail };

                    Cage.OrderDetails = new List<OrderDetailDTO>() { orderDetail };
                }

                var result = _cageRepository.AddNewCage(Cage);

                if (result)
                {
                    TempData["notification"] = "Create new cage successfully";
                }
                else
                {
                    TempData["notification"] = "Create new cage failed";
                }
            }
            else
            {
                TempData["notification"] = "Create new cage failed";
            }
            return RedirectToPage("./Index");
        }


        public struct cageStatus
        {
            public string stringStatus { get; set; }
            public int intStatus { get; set; }
            public cageStatus(string stringStatus, int intStatus)
            {
                this.stringStatus = stringStatus;
                this.intStatus = intStatus;
            }
        }
    }
}
