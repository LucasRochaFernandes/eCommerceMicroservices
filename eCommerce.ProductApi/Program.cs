using eCommerce.ProductApi.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.AddInfrastructurePolicy();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
