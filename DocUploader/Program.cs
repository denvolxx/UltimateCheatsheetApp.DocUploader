using DocUploader;
using DocUploader.Data;
using DocUploader.Helpers;
using DocUploader.Services.CacheService;
using DocUploader.Services.DatabaseServices.ProductService;
using DocUploader.Services.FileProcessingService.FileProcessingService;
using StackExchange.Redis;

var builder = Host.CreateApplicationBuilder(args);

//MongoDB
builder.Services.AddSingleton<MongoDataContext>(_ => new MongoDataContext(builder.Configuration.GetConnectionString("MongoConnection")!,
    "CheatsheetAppMongo"));

//Hosted services
builder.Services.AddHostedService<ConsumerService>();

//Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration.GetSection("RedisConnection").Value!));

//Helpers
builder.Services.AddSingleton<IFileProcessingService, FileProcessingService>();
builder.Services.AddSingleton<ICacheService, CacheService>();

//DB services
builder.Services.AddSingleton<IProductService, ProductService>();

var host = builder.Build();

host.Run();
