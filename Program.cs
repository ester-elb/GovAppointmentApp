using AppointmentApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add AWS Lambda support
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

// MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
    
    if (string.IsNullOrEmpty(connectionString))
    {
        connectionString = builder.Configuration.GetValue<string>("MongoDB:ConnectionString");
    }
    
    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("MongoDB connection string not found");
        
    return new MongoClient(connectionString);
});


// Services
builder.Services.AddSingleton<AppointmentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Support for dynamic port (Railway, Render, etc.)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
