using Backend.Data;
using Backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context) => _context = context;

        [HttpPost("login")]
        public async Task<ActionResult<ClientInfoDto>> Login(LoginDto loginDto)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == loginDto.Login);
            if (client == null || client.Password != loginDto.Password)
                return Unauthorized();

            var orders = await _context.Orders.Where(o => o.ClientID == client.Id).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();

            var ordersDto = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                Date = o.Date,
                Items = o.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductName = oi.Product.Name,
                    Count = oi.Count,
                    PriceAtPurchase = oi.Product.Price
                }).ToList()
            }).ToList();

            return Ok(new ClientInfoDto
            {
                Id = client.Id,
                Name = client.Name,
                Balance = client.Balance,
                Orders = ordersDto
            });
        }
    }
}
