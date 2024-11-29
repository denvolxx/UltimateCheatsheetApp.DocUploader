using Confluent.Kafka;
using DocUploader.Services.CacheService;
using DocUploader.Services.FileProcessingService.FileProcessingService;

namespace DocUploader
{
    public class ConsumerService(ILogger<ConsumerService> logger, IConfiguration config, IFileProcessingService fileProcessor, ICacheService cacheService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("BackgroundService started");
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test-group"
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

            consumer.Subscribe(config.GetSection("Topic").Value);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumerResult = consumer.Consume();

                    if (consumerResult == null)
                    {
                        continue;
                    }

                    var fileBytes = await cacheService.GetCachedFileAsync(consumerResult.Message.Value);
                    if (fileBytes == null)
                        throw new Exception("Can not retrieve file from cache");

                    //Process file and save it to database
                    await fileProcessor.ProcessProducts(fileBytes);

                    logger.LogInformation($"Consumed message with {consumerResult.Topic} topic at: '{consumerResult.Offset}'");
                    logger.LogInformation($"Message: '{consumerResult.Message.Value}'");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
