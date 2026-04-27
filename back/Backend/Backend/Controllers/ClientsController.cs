using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        //Get: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        //Get: api/Clients/x
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInfoDto>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            // Загружаем заказы клиента с их позициями и товарами
            var orders = await _context.Orders
                .Where(o => o.ClientID == client.Id)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

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

            var result = new ClientInfoDto
            {
                Id = client.Id,
                Name = client.Name,
                Balance = client.Balance,
                Orders = ordersDto
            };
            return Ok(result);
        }

        //Post: api/Clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(p => p.Id == id);
        }

        //Delete: api/Clients/x
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

    }
}
