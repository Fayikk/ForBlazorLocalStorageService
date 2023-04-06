namespace ForBlazorLocalStorageService.Client.Services.Order
{
    public interface IOrderService
    {
        List<Model> models { get; set; }
        List<Product> products { get; set; }    
        Task CreateOrder();
    }
}
