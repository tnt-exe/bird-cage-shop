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

        public IActionResult OnGetRemoveCageItem(int? detailId, int orderId)
        {
            if (detailId != null)
            {
                var order = _orderRepository.GetOrderById(orderId);
                var detail = _orderDetailRepository.getOrderDetailById((int)detailId);
                order.TotalPrice -= detail.Price;

                _orderRepository.UpdateOrder(order);

                _orderDetailRepository.DeleteOrderDetail((int)detailId);
                return RedirectToPage("./Details", new { Id = orderId });
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
