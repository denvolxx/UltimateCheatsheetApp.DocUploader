using DocUploader.Data;
using DocUploader.Models;

namespace DocUploader.Services.DatabaseServices.ProductService
{
    public class ProductService(MongoDataContext context) : IProductService
    {
        public async Task AddProducts(List<Product> product)
        {
            await context.Products.InsertManyAsync(product);
        }
    }
}
