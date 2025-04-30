using EMS.API.Data;
using EMS.API.Repositories.Abstract;
using EMS.API.Repositories.Implementation;
using EMS.API.Services.Abstract;
using EMS.API.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("No Connection String was found");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();

    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

}


var app = builder.Build();
{
    app.UseDefaultFiles();
    app.UseStaticFiles();

    if (app.Environment.IsDevelopment())
        app.UseSwagger()
           .UseSwaggerUI();


    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.MapFallbackToFile("/index.html");

    app.Run();
}
