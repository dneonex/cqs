using CommandQuery.AspNetCore;
using Recruitment.Contracts.Commands;
using Recruitment.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add Commands
builder.Services.AddCommandControllers(typeof(CalculateHashCommandHandler).Assembly, typeof(CalculateHashCommand).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHealthChecks("/healthcheck");

app.Run();

// To it access from Tests
public partial class Program { }