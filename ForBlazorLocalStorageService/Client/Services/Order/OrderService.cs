using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace ForBlazorLocalStorageService.Client.Services.Order
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

        public List<Model> models { get ; set ; } = new List<Model>();  
        public List<Product> products { get ; set ; }

        public async Task CreateOrder()
        {
            var result1 =await _service.GetItemAsync<List<Product>>("products");

            foreach (var item in result1)
            {
                Model model = new Model();

                model.Name = item.Name;
                model.Description=item.Description;
                models.Add(model);
            }

            var result = await _client.PostAsJsonAsync("api/order", models);

        }
    }
}
