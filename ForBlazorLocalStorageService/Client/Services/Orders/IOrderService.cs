using ForBlazorLocalStorageService.Shared;

namespace ForBlazorLocalStorageService.Client.Services.Orders
{
    public interface IOrderService
    {
        List<Order> orders { get; set; }
        List<Product> products { get; set; }    
        Task CreateOrder();
    }
}
