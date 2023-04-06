
using Blazored.LocalStorage;

namespace ForBlazorLocalStorageService.Client.Services
{
    public class CartExampleService : ICartExampleService
    {
        private readonly ILocalStorageService _localStorageService;

        public CartExampleService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public async Task CreateProductAsync(Product product)
        {
            // Get existing products from local storage
            var existingProducts = await _localStorageService.GetItemAsync<List<Product>>("products") ?? new List<Product>();

            // Set new product's ID
            product.Id = existingProducts.Any() ? existingProducts.Max(p => p.Id) + 1 : 1;

            // Add the new product to the list
            existingProducts.Add(product);

            // Save the updated list to local storage
            await _localStorageService.SetItemAsync("products", existingProducts);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Get existing products from local storage
            var existingProducts = await _localStorageService.GetItemAsync<List<Product>>("products") ?? new List<Product>();

            // Find the index of the product with the same ID
            var index = existingProducts.FindIndex(p => p.Id == product.Id);

            // If the product is found, update it
            if (index != -1)
            {
                existingProducts[index] = product;

                // Save the updated list to local storage
                await _localStorageService.SetItemAsync("products", existingProducts);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            // Get existing products from local storage
            var existingProducts = await _localStorageService.GetItemAsync<List<Product>>("products") ?? new List<Product>();

            // Find the product with the given ID
            var product = existingProducts.FirstOrDefault(p => p.Id == id);

            // If the product is found, remove it from the list and save to local storage
            if (product != null)
            {
                existingProducts.Remove(product);
                await _localStorageService.SetItemAsync("products", existingProducts);
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            // Get existing products from local storage
            var existingProducts = await _localStorageService.GetItemAsync<List<Product>>("products") ?? new List<Product>();

            return existingProducts;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            // Get existing products from local storage
            var existingProducts = await _localStorageService.GetItemAsync<List<Product>>("products") ?? new List<Product>();

            // Find the product with the given ID
            var product = existingProducts.FirstOrDefault(p => p.Id == id);

            return product;
        }

        


    }
}
