using ForBlazorLocalStorageService.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForBlazorLocalStorageService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Order> Create(List<Order> order)
        {
            _context.Orders.AddRangeAsync(order);
            await _context.SaveChangesAsync();
            return order[0];
        }
    }
}
