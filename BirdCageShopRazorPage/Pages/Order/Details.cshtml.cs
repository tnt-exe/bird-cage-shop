using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using OrderEntity = BusinessObject.Models.Order;
using DataTransferObject;
using Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace BirdCageShopRazorPage.Pages.Order
{
    [Authorize(Policy = "Customer")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public DetailsModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
    }
}
