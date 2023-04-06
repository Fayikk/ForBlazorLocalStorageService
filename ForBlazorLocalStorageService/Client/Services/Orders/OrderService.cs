using Blazored.LocalStorage;
using ForBlazorLocalStorageService.Shared;
using System.Net.Http.Json;

namespace ForBlazorLocalStorageService.Client.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _service;
        public OrderService(HttpClient client,ILocalStorageService service)
        {
            _service = service;
            _client = client;
        }

        public List<Product> products { get ; set ; }
        public List<Order> orders { get ; set ; }=new List<Order>();

        public async Task CreateOrder()
        {
            var result1 =await _service.GetItemAsync<List<Product>>("products");

            foreach (var item in result1)
            {
                Order model = new Order();

                model.Name = item.Name;
                model.Description=item.Description;
                orders.Add(model);
            }

            var result = await _client.PostAsJsonAsync("api/order", orders);

            await _service.RemoveItemAsync("products");

        }
    }
}
