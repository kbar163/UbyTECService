using System.Text.Json.Serialization;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<ubytecdbContext>();
builder.Services.AddMvc()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUbyAdminRepository,UbyAdminRepository>();
builder.Services.AddScoped<IDeliverymanRepository,DeliverymanRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IAfiliateRepository,AfiliateRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICommerceTypeRepository,CommerceTypeRepository>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//Middleware utilizado para habilitar politicas de CORS en los endpoints del REST API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
    policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
