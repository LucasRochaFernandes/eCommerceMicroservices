using eCommerce.OrderApi.Infrastructure.Database;
using eCommerce.OrderApi.Infrastructure.Extensions;
using eCommerce.SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderApiDbContext>();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.AddSharedMiddlewares();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

