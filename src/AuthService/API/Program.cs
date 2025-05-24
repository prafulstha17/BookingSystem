using Api.Middleware;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ErrorHandingMiddleware>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*// Run database seeding after application starts
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedStaticData>>();
    var seedData = new SeedStaticData(logger);

    await seedData.SeedStaticDataAsync(context);
}
*/


app.UseMiddleware<ErrorHandingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
