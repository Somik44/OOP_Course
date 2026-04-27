namespace Backend.DTO
{
    public class LoginDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class ClientInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        // Список покупок (заказов)
        public List<OrderDto> Orders { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public int Count { get; set; }
        public float PriceAtPurchase { get; set; }
    }

    public class PurchaseRequestDto
    {
        public int ClientId { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }

    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
