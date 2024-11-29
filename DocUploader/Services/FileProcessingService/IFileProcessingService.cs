namespace DocUploader.Services.FileProcessingService.FileProcessingService
{
    public interface IFileProcessingService
    {
        Task ProcessProducts(byte[] fileBytes);
    }
}
