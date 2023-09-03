using BookService.DbContexts;
using BookService.Services;
using BookService.Utility;
using BookService.Utility.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IBookSvc, BookSvc>();
builder.Services.AddScoped<IBookTransformer, BookTransformer>();

builder.Services.AddTransient<ILifeTransient, ServicesLifeTimes>();
builder.Services.AddScoped<ILifeScoped, ServicesLifeTimes>();
builder.Services.AddSingleton<ILifeSingleton, ServicesLifeTimes>();

builder.Services.AddScoped<IServicesLifeTimesReq, ServiceLifeTimeSameReq>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
