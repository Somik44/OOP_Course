using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Lab_6_Internet_Shop.DTO;

namespace Lab_6_Internet_Shop
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5038/api";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProductDto>>($"{_baseUrl}/Products");
            return response ?? new List<ProductDto>();
        }

        public async Task<ClientInfoDto> LoginAsync(string login, string password)
        {
            var loginData = new { Login = login, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Auth/login", loginData);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ClientInfoDto>();
            return null;
        }

        public async Task<bool> PurchaseAsync(int clientId, List<(int productId, int count)> items)
        {
            var request = new
            {
                ClientId = clientId,
                Items = items.Select(i => new { ProductId = i.productId, Count = i.count })
            };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Orders", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<ClientInfoDto> GetClientInfoAsync(int clientId)
        {
            var response = await _httpClient.GetFromJsonAsync<ClientInfoDto>($"{_baseUrl}/Clients/{clientId}");
            return response;
        }
    }
}
