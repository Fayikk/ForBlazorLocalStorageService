namespace ForBlazorLocalStorageService.Client.Services
{
    public interface ICartExampleService
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
    }
}
