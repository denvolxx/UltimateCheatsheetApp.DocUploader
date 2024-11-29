using DocUploader.Models;

namespace DocUploader.Services.DatabaseServices.ProductService
{
    public interface IProductService
    {
        Task AddProducts(List<Product> product);
    }
}
