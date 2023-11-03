using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace BirdCageShopRazorPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentController(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetComponentPrice(int id)
        {
            var price = _componentRepository.GetComponentById(id).ComponentPrice;
            return Ok(new { price = price });
        }
    }
}
