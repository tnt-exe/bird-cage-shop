using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Order
{
    [Authorize(Policy = "Customer")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;


        public DetailsModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDTO Order { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var order = _orderRepository.GetOrderById(id ?? 0);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }

        //public IActionResult OnPost(int? orderId)
        //{
        //    return Page();
        //}

        public IActionResult OnGetRemoveCageItem(int? detailId)
        {
            if (detailId != null)
            {
                _orderDetailRepository.DeleteOrderDetail((int)detailId);
                return RedirectToPage();
            }
            return NotFound();
        }

        public IActionResult OnGetConfirmOrder(int? orderId)
        {
            if (orderId != null)
            {
                _orderRepository.ChangeOrderStatus((int)orderId, (int)OrderStatus.Pending);
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
