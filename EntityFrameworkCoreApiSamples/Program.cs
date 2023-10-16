using EntityFrameworkCoreApiSamples.DataContext;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodosContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("TodosContext"));
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(setupAction =>
    {
        setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        setupAction.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
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
