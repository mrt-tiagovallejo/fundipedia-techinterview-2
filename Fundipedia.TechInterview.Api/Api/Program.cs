using Fundipedia.TechInterview.Domain.Classes;
using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy => policy.WithOrigins("http://localhost:8080") // Replace with your frontend URL
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderStatusEvaluator, OrderStatusEvaluator>();

var app = builder.Build();

// Enable the CORS policy
app.UseCors("AllowVueApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/orders/status", (OrderRequest request, IOrderStatusEvaluator evaluator) =>
{
    var status = evaluator.Evaluate(request);
    return Results.Ok(status.ToString());
})
.WithName("OrdersStatus")
.WithOpenApi();

app.Run();
