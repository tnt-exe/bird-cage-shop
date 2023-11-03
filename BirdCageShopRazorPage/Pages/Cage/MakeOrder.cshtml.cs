using AutoMapper;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.Security.Claims;

namespace BirdCageShopRazorPage.Pages.Cage
{
    [Authorize]
    public class MakeOrderModel : PageModel
    {
        private readonly ICageRepository _cageRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public MakeOrderModel(ICageRepository cageRepository,
            IHttpContextAccessor httpContextAccessor,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IMapper mapper)
        {
            _cageRepository = cageRepository;
            _httpContextAccessor = httpContextAccessor;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public CageDTO Cage { get; set; } = default!;

        public OrderDetailDTO OrderDetail { get; set; } = default!;

        public Decimal TotalMoney { get; set; } = 0;

        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public int CageId { get; set; }

        [BindProperty]
        public int OrderDetailId { get; set; }

        public IActionResult OnGet(int? id)
        {
            var cage = _cageRepository.GetCageById(id ?? 0);
            if (cage == null)
            {
                return NotFound();
            }
            else
            {
                Cage = cage;
            }

            //Need to get order detail
            var userIdString = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var check = int.TryParse(userIdString, out var userId);
            if (check)
            {
                var order = _orderRepository.GetLatestSuitableOrderOfUser(userId);
                if (order is not null)
                {
                    var existedOrderDetail = order.OrderDetails.Where(od => od.CageId == id).FirstOrDefault();
                    if (existedOrderDetail is not null)
                    {
                        OrderDetail = _mapper.Map<OrderDetailDTO>(existedOrderDetail);
                        TotalMoney = OrderDetail.Price ?? 0;
                        Quantity = OrderDetail.Quantity ?? 0;
                        OrderDetailId = OrderDetail.OrderDetailId;
                    }
                }
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            OrderDetail = _orderDetailRepository.getOrderDetailById(OrderDetailId);

            var cage = _cageRepository.GetCageById(CageId);
            if (cage == null)
            {
                TempData["notification"] = "Thêm vào giỏ hàng thất bại";
                return RedirectToPage("./Index");
            }
            else
            {
                Cage = cage;
            }

            if (OrderDetail is not null)
            {
                var order = _orderRepository.GetOrderById(OrderDetail.OrderId ?? 0);
                if (order is not null)
                {
                    if (Quantity == OrderDetail.Quantity)
                    {
                        TempData["notification"] = "Cập nhật giỏ hàng thất bại";
                    }
                    else
                    {
                        order.TotalPrice += (Quantity - OrderDetail.Quantity) * Cage.CagePrice;
                        OrderDetail.Quantity = Quantity;
                        OrderDetail.Price = Quantity * Cage.CagePrice;
                        var c1 = _orderRepository.UpdateOrder(_mapper.Map<BusinessObject.Models.Order>(order));
                        var c2 = _orderDetailRepository.UpdateOrderDetail(OrderDetail);

                        if (c1 && c2)
                        {
                            TempData["notification"] = "Cập nhật giỏ hàng thành công";
                        }
                        else
                        {
                            TempData["notification"] = "Cập nhật giỏ hàng thất bại";
                        }
                    }
                }
                else
                {
                    TempData["notification"] = "Cập nhật giỏ hàng thất bại";
                }
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var check = int.TryParse(userId, out var id);
                if (check)
                {
                    // Lấy ra giỏ hàng mới nhất của khách hàng
                    var order = _orderRepository.GetLatestSuitableOrderOfUser(id);
                    if (order is null)
                    {
                        // Tạo mới đơn hàng
                        OrderDetailDTO newOrderDetail = new OrderDetailDTO
                        {
                            Quantity = Quantity,
                            Price = Cage.CagePrice * Quantity,
                            CageId = Cage.CageId,
                        };
                        // Tạo mới giỏ hàng
                        OrderDTO newOrder = new OrderDTO
                        {
                            UserId = id,
                            TotalPrice = newOrderDetail.Price,
                            OrderDate = DateTime.Now,
                            Status = (int)BusinessObject.Enums.OrderStatus.Waiting
                        };

                        newOrder.OrderDetails = new List<OrderDetailDTO>() { newOrderDetail };

                        var result = _orderRepository.CreateOrder(newOrder);

                        if (result)
                        {
                            TempData["notification"] = "Thêm vào giỏ hàng thành công";
                        }
                        else
                        {
                            TempData["notification"] = "Thêm vào giỏ hàng thất bại";
                        }
                    }
                    else
                    {
                        OrderDetailDTO newOrderDetail = new OrderDetailDTO
                        {
                            Quantity = Quantity,
                            Price = Cage.CagePrice * Quantity,
                            CageId = Cage.CageId,
                            OrderId = order.OrderId
                        };
                        order.TotalPrice += Cage.CagePrice * Quantity;

                        var c1 = _orderRepository.UpdateOrder(order);
                        var c2 = _orderDetailRepository.AddNewOrderDetail(newOrderDetail);

                        if (c1 && c2)
                        {
                            TempData["notification"] = "Thêm vào giỏ hàng thành công";
                        }
                        else
                        {
                            TempData["notification"] = "Thêm vào giỏ hàng thất bại";
                        }
                    }
                }
                else
                {
                    TempData["notification"] = "Thêm vào giỏ hàng thất bại";
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
