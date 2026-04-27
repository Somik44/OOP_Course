using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }

    public class ClientInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
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
}
