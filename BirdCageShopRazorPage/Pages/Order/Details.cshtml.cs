using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.Data;

namespace BirdCageShopRazorPage.Pages.Order
{
    [Authorize(Policy = "Customer")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICageRepository _cageRepository;

        public DetailsModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, ICageRepository cageRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _cageRepository = cageRepository;
        }

        public OrderDTO Order { get; set; } = default!;

        [BindProperty]
        public decimal? Price { get; set; }

        [BindProperty]
        public int? CageId { get; set; }

        [BindProperty]
        public int? OrderId { get; set; }


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
                if (order.Status == (int)OrderStatus.Custom)
                {
                    CageId = order.OrderDetails.FirstOrDefault()?.CageId;
                    OrderId = order.OrderId;
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Price != null && Price != 0)
            {
                var order = _orderRepository.GetOrderById(OrderId ?? 0);
                var orderDetail = order.OrderDetails.Where(od => od.CageId == CageId).FirstOrDefault();
                var cage = order.OrderDetails.Where(od => od.CageId == CageId).FirstOrDefault()?.Cage;
                if (cage != null && order != null && orderDetail != null)
                {
                    cage.CagePrice = Price;
                    cage.Status = (int)CageStatus.Available;
                    _cageRepository.UpdateCage(cage);

                    orderDetail.Price = Price * orderDetail.Quantity;
                    _orderDetailRepository.UpdateOrderDetail(orderDetail);

                    order.Status = (int)OrderStatus.Dealing;
                    order.TotalPrice = orderDetail.Price;
                    _orderRepository.UpdateOrder(order);
                }
            }
            return RedirectToPage("./Index");
        }

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

        public IActionResult OnGetConfirmOrder(int? orderId, int? status)
        {
            if (orderId != null)
            {
                int updateStatus = -1;
                switch (status)
                {
                    case 0:
                        updateStatus = (int)OrderStatus.Processing;
                        break;
                    case 1:
                        updateStatus = (int)OrderStatus.Completed;
                        break;
                    case 4:
                        updateStatus = (int)OrderStatus.Pending;
                        break;
                    case 6:
                        updateStatus = (int)OrderStatus.Pending;
                        break;
                }
                _orderRepository.ChangeOrderStatus((int)orderId, updateStatus);
                return RedirectToPage("./Index");
            }
            return NotFound();
        }

        public IActionResult OnGetCancelOrder(int? orderId)
        {
            if (orderId != null)
            {
                _orderRepository.ChangeOrderStatus((int)orderId, (int)OrderStatus.Cancelled);
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
