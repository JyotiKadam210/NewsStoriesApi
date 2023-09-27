using NewsStoriesApi.Client;
using NewsStoriesApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("NewsApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["HackerNewsUrl"]);
});

builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<INewsClient, HackerNewsClient>();

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
