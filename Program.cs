using dot7.API.Crud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//*************     Services start
// Add services to the container.

builder.Services.AddDbContext<MyWorldDbContext>(
options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyWorldDbConnection"));
}
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//*************     Servives end

//***********       Middlewares Starts
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

//***************  Middlewares End

app.Run();
