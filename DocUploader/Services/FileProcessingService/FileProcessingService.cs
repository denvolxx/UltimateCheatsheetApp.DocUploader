using DocUploader.Models;
using DocUploader.Services.DatabaseServices.ProductService;
using OfficeOpenXml;

namespace DocUploader.Services.FileProcessingService.FileProcessingService
{
    public class FileProcessingService(IProductService productService) : IFileProcessingService
    {
        public async Task ProcessProducts(byte[] fileBytes)
        {
            using var stream = new MemoryStream(fileBytes);
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var userList = new List<Product>();

                //We start from second row, because first row will be headers
                for (int row = 2; row <= rowCount; row++)
                {
                    var user = new Product
                    {
                        Name = worksheet.Cells[row, 1].Value.ToString(),
                        Price = worksheet.Cells[row, 2].Value.ToString()
                    };
                    userList.Add(user);
                }

                Console.WriteLine($"Amount ow rows = {userList.Count}");

                //Save products to database
                await productService.AddProducts(userList);
            }
        }
    }
}
