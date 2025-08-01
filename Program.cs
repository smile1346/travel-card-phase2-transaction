using Microsoft.EntityFrameworkCore;
using TransactionService.Data;
using TransactionService.Services;
using TransactionService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context
builder.Services.AddDbContext<TransactionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository Pattern
builder.Services.AddScoped<ISpendingRepository, SpendingRepository>();
// builder.Services.AddScoped<ICashWithdrawalRepository, CashWithdrawalRepository>();

// Business Services
builder.Services.AddScoped<ISpendingService, SpendingService>();
// builder.Services.AddScoped<ICashWithdrawalService, CashWithdrawalService>();

// HTTP Clients for other microservices
builder.Services.AddHttpClient("TripService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:TripService:BaseUrl"]);
});

builder.Services.AddHttpClient("SplitService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:SplitService:BaseUrl"]);
});

builder.Services.AddHttpClient("LocationService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:LocationService:BaseUrl"]);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.AllowAnyOrigin() // 🔒 Allow only this domain
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();