using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdersController(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> CreateOrder(PurchaseRequestDto purchase)
        {
            // Начинаем транзакцию, чтобы согласованно обновить баланс, остатки и создать заказ
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var client = await _context.Clients.FindAsync(purchase.ClientId);
                if (client == null) return BadRequest("Client not found");

                float total = 0;
                var itemsToBuy = new List<(Product product, int count)>();
                foreach (var req in purchase.Items)
                {
                    var product = await _context.Products.FindAsync(req.ProductId);
                    if (product == null) return BadRequest($"Product {req.ProductId} not found");
                    if (product.Count < req.Count) return BadRequest($"Not enough stock for {product.Name}");
                    itemsToBuy.Add((product, req.Count));
                    total += product.Price * req.Count;
                }

                if (client.Balance < total) return BadRequest("Insufficient funds");

                client.Balance -= total;
                foreach (var (product, cnt) in itemsToBuy)
                {
                    product.Count -= cnt;
                }

                var order = new Order
                {
                    ClientID = client.Id,
                    Date = DateTime.UtcNow
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var (product, cnt) in itemsToBuy)
                {
                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Count = cnt
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { orderId = order.Id });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
