using CourseAttendanceAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

var sqlConnectionBuilder = new SqlConnectionStringBuilder();
sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
//If needed to use secrets for SA user authentication in sql server
//sqlConnectionBuilder.UserID = builder.Configuration["UserId"];
//sqlConnectionBuilder.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(sqlConnectionBuilder.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DataSeeder.PopulateMockData(app);

app.Run();
